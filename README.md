## Simple UI Test and Unit Test Sample App
This app shows how to implement UITest and Unit Tests into a Xamarin.Forms project.

The UITests follow the recommended practice of Page Object testing. In the views, we've added an `AutomationId` to each control to show how UITest can interact with controls using their AutomationId. It also demonstrates how to utilize [Backdoors in UITest](https://developer.xamarin.com/guides/testcloud/uitest/working-with/backdoors/) to bypass login screens to improve the speed of the test. The login page leverages the [Reusable Login Page](https://github.com/michael-watson/Forms-Expenses) created by [Michael Watson](https://github.com/michael-watson).

There are two UnitTest project includes a sample iOS unit test, one of which uses an [iOS Test Runner](https://developer.xamarin.com/guides/ios/deployment,_testing,_and_metrics/touch.unit/#Running_Your_Tests) to run platform-specific unit tests.

The branch [NoLoginPage](https://github.com/brminnick/SimpleUITestApp/tree/NoLoginPage) contains a simpler version of the app that doesn't include the login page or any backdoor UITests. 

Author
===
Brandon Minnick

Xamarin Customer Success Engineer

### Licensing
MIT License

Copyright (c) 2016 Brandon Minnick

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
