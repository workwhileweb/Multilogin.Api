<img src="https://multilogin.com/wp-content/themes/multilogin/dist/images/logo-blue_0d908f50.svg" width="150" align="right" />

# Multilogin API Client
[Multilogin](https://multilogin.com/) is a complete and integrated solution for browser fingerprinting protection, and also for easy browser automation using W3C WebDriver. 
This .NET Core package provides convenient access to the REST interface of the Multilogin aka. Indigo Client.

Consider giving it a ⭐ on Github, it was a lot of work.

[Nuget](https://www.nuget.org/packages/Multilogin.Api)

# Features
- Fully customizable browser fingerprint (Indigo/Multilogin) ([What is a browser fingerprint?](https://en.wikipedia.org/wiki/Device_fingerprint#Browser_fingerprint))
- Local & Remote API Support, Automated API Key Retrival
- Selenium compatible
- Import [creepjs](https://abrahamjuliot.github.io/creepjs/) fingerprint easily
- Create/Modify/Delete/Share/Clone/Start profiles (via ID identifier)
- Create/Modify/Delete groups (via ID identifier)
- Get active plan data, fonts and resolutions
- Fail-Safe browser handling (cookies, starting, etc.)
- ... and more!

# Quickstart Guide
```csharp

// Initialize client
var client = new MLAClient();

// Create new profile and start it
var profile = client.CreateProfile("test profile", new Guid(), OS.Android, Browser.MimicMobile, ProxyType.None);

var options = new ChromeOptions();
await profile.Start(options);

// Use any WebDriver command to drive the browser
// and enjoy full protection from Selenium detection methods
var webDriver = profile.WebDriver;

webDriver.Navigate().GoToUrl("https://google.com");
webDriver.FindElement(By.CssSelector("div[aria-modal=\"true\"][tabindex=\"0\"] button:not([aria-label]):last-child")).Click();
webDriver.FindElement(By.Name("q")).SendKeys("Multilogin");
webDriver.FindElement(By.Name("q")).SendKeys(Keys.Enter);

await Task.Delay(5000);
var title = webDriver.Title;
Console.WriteLine("The title is " + title);

// Stop profile & driver
await profile.Stop();
webDriver.Quit();

```

# Example codes
All examples can be found in the [testing project](https://github.com/earthlion/Multilogin.Api/tree/main/Multilogin.Api.Tests).
If you have any questions, feel free to open an issue on Github.

# Credits
🧍 [Me](https://github.com/earthlion) - API<br/>

# License
This project is released under MIT License. Please refer the LICENSE.txt for more details.
