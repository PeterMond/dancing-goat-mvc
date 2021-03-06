﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CMS.DocumentEngine.Types;
using CMS.Globalization;

using MvcDemo.Web.Infrastructure;
using MvcDemo.Web.Models.Contacts;
using MvcDemo.Web.Repositories;
using MvcDemo.Web.Services;

namespace MvcDemo.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ICafeRepository mCafeRepository;
        private readonly IContactRepository mContactRepository;
        private readonly ICountryRepository mCountryRepository;
        private readonly IFormItemRepository mFormItemRepository;
        private readonly LocalizationService mLocalizationService;
        private readonly ISocialLinkRepository mSocialLinkRepository;
        private readonly IOutputCacheDependencies mOutputCacheDependencies;


        public ContactsController(ICafeRepository cafeRepository, ISocialLinkRepository socialLinkRepository,
            IContactRepository contactRepository, IFormItemRepository formItemRepository,
            ICountryRepository countryRepository, LocalizationService localizationService, IOutputCacheDependencies outputCacheDependencies)
        {
            mLocalizationService = localizationService;
            mCountryRepository = countryRepository;
            mFormItemRepository = formItemRepository;
            mCafeRepository = cafeRepository;
            mSocialLinkRepository = socialLinkRepository;
            mContactRepository = contactRepository;
            mOutputCacheDependencies = outputCacheDependencies;
        }


        // GET: Contacts
        [OutputCache(CacheProfile = "Default", VaryByParam = "none")]
        public ActionResult Index()
        {
            var model = GetIndexViewModel();
            model.Message = new MessageModel();

            mOutputCacheDependencies.AddDependencyOnPages<Cafe>();
            mOutputCacheDependencies.AddDependencyOnPages<Contact>();
            mOutputCacheDependencies.AddDependencyOnInfoObjects<CountryInfo>();
            mOutputCacheDependencies.AddDependencyOnInfoObjects<StateInfo>();

            return View(model);
        }


        // GET: Contacts/ThankYou
        public ActionResult ThankYou()
        {
            var model = GetIndexViewModel();
            model.MessageSent = true;

            return View("Index", model);
        }


        // POST: Contacts/SendMessage
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SendMessage(MessageModel message)
        {
            if (!ModelState.IsValid)
            {
                var model = GetIndexViewModel();
                model.Message = message;

                return View("Index", model);
            }

            try
            {
                mFormItemRepository.CreateContactUsFormItem(message);
            }
            catch
            {
                return View("Error");
            }

            return RedirectToAction("ThankYou");
        }


        [ChildActionOnly]
        [ValidateInput(false)]
        public ActionResult CompanyAddress()
        {
            var address = GetCompanyContactModel();

            mOutputCacheDependencies.AddDependencyOnPages<Cafe>();
            mOutputCacheDependencies.AddDependencyOnPages<Contact>();
            mOutputCacheDependencies.AddDependencyOnInfoObjects<CountryInfo>();
            mOutputCacheDependencies.AddDependencyOnInfoObjects<StateInfo>();

            return PartialView("_Address", address);
        }


        [ChildActionOnly]
        [ValidateInput(false)]
        public ActionResult CompanySocialLinks()
        {
            var socialLinks = mSocialLinkRepository.GetSocialLinks();

            mOutputCacheDependencies.AddDependencyOnPages<SocialLink>();

            return PartialView("_SocialLinks", socialLinks);
        }


        private IndexViewModel GetIndexViewModel()
        {
            var cafes = mCafeRepository.GetCompanyCafes(4);

            return new IndexViewModel
            {
                CompanyContact = GetCompanyContactModel(),
                CompanyCafes = GetCompanyCafesModel(cafes)
            };
        }


        private ContactModel GetCompanyContactModel()
        {
            return CreateContactModel(mContactRepository.GetCompanyContact());
        }


        private List<ContactModel> GetCompanyCafesModel(IEnumerable<Cafe> cafes)
        {
            return cafes.Select(CreateContactModel).ToList();
        }


        private ContactModel CreateContactModel(IContact contact)
        {
            var countryStateName = CountryStateName.Parse(contact.Country);
            var country = mCountryRepository.GetCountry(countryStateName.CountryName);
            var state = mCountryRepository.GetState(countryStateName.StateName);

            var model = new ContactModel(contact)
            {
                CountryCode = country.CountryTwoLetterCode,
                Country = mLocalizationService.LocalizeString(country.CountryDisplayName)
            };

            if (state != null)
            {
                model.StateCode = state.StateName;
                model.State = mLocalizationService.LocalizeString(state.StateDisplayName);
            }

            return model;
        }
    }
}