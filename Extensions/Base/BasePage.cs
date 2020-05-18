﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Extensions.Pages.Base
{
  public abstract class BasePage : IBasePage
  {
    protected IWebDriver _webDriver;
    protected WebDriverWait _driverWaiter;
    protected Dictionary<string, IWebElement> _elements;
    protected Dictionary<string, IWebElement[]> _collections;
    protected string _pageUrl;
    protected string _pageObjectName;

    public BasePage(IWebDriver webDriver)
    {
      _webDriver = webDriver;
      _driverWaiter = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 3));
    }

    private void Wait(string elementName)
    {
      _driverWaiter.Until(_ => _elements[elementName].Displayed);
    }

    public void Click(string elementName)
    {
      Wait(elementName);
      _elements[elementName].Click();
    }

    public void ClickCollectionElement(string collectionName, int elementOrder)
    {
      _driverWaiter.Until(_ => _collections[collectionName][elementOrder].Displayed);
      _collections[collectionName][elementOrder - 1].Click();
    }

    public void SendText(string elementName, string text)
    {
      Wait(elementName);
      _elements[elementName].SendKeys(text);
    }

    public void OpenPage()
    {
      _webDriver.Navigate().GoToUrl(_pageUrl);
    }

    public string GetPageObjectName()
    {
      return _pageObjectName;
    }
  }
}