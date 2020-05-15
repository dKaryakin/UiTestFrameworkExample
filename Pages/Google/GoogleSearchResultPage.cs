﻿using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages.Google
{
  public sealed class GoogleSearchResultPage : BasePage, IBasePage
  {
    // put element description here
    [FindsBy(How = How.XPath, Using = "//div[@id='rso']/div[@class='g']")]
    public IWebElement[] searchResults;

    public GoogleSearchResultPage(IWebDriver webDriver) : base(webDriver)
    {
      PageFactory.InitElements(_webDriver, this);
      _collections = new Dictionary<string, IWebElement[]>()
      {
        { "Search results", searchResults }
      };
    }
  }
}
