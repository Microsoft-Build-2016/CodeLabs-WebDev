<a name="HOLTop" ></a>
# Introduction to ASP.NET Core 1.0 #

---

<a name="Overview" ></a>
## Overview ##

**ASP.NET Core 1.0** is a new [open-source](https://github.com/aspnet/home) and cross-platform framework for building modern cloud-based Web applications using .NET. It was built from the ground up to provide an optimized development framework for apps that are either deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core 1.0 applications cross-platform on Windows, Mac and Linux.

ASP.NET Core 1.0 is built with the needs of modern Web applications in mind, including a unified story for building Web UI and Web APIs that integrate with today’s modern client-side frameworks and development workflows. It's also built to be cloud-ready by introducing environment-based configuration and by providing built-in dependency injection support.

This module demonstrates how to create a simple **ASP.NET Core 1.0** project using **Visual Studio 2015** in **Windows**, as well as a simple web application using **Yeoman** and **Visual Studio Code** in **Ubuntu**.


<a name="Objectives" ></a>
### Objectives ###
In this module, you will:

- Create a Web site based on the **ASP.NET Core 1.0** template
- Walk through and understand the main components of an **ASP.NET Core 1.0** application
- Scaffold the required components to create a CRUD **ASP.NET Core 1.0** application
- Create a unit test project
- Create and run an **ASP.NET Core 1.0** application in Ubuntu

<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this module:

- [Visual Studio Community 2015][1] or greater
- [ASP.NET Core 1.0][2]

[1]: https://www.visualstudio.com/products/visual-studio-community-vs
[2]: https://get.asp.net

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.

<a name="Setup" ></a>
### Setup ###
In order to run the exercises in this module, you'll need to set up your environment first.

1. Open Windows Explorer and browse to the module's **Source** folder.
1. Right-click **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this module.
1. If the User Account Control dialog box is shown, confirm the action to proceed.

> **Note:** Make sure you've installed all the dependencies for this module before running the setup.

<a name="CodeSnippets" ></a>
### Using the Code Snippets ###

Throughout the module document, you'll be instructed to insert code blocks. For your convenience, most of this code is provided as Visual Studio Code Snippets, which you can access from within Visual Studio 2015 to avoid having to add it manually.

>**Note**: Each exercise is accompanied by a starting solution located in the **Begin** folder of the exercise that allows you to follow each exercise independently of the others. Please be aware that the code snippets that are added during an exercise are missing from these starting solutions and may not work until you've completed the exercise. Inside the source code for an exercise, you'll also find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the corresponding exercise. You can use these solutions as guidance if you need additional help as you work through this module.

---

<a name="Exercises" ></a>
## Exercises ##
This module includes the following exercises:

1. [Creating a new web site with Visual Studio 2015](#Exercise1)
1. [Working with Data](#Exercise2)
1. [Unit testing your apps](#Exercise3)
1. [Cross-platform development](#Exercise4)

Estimated time to complete this module: **60 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this module describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1" ></a>
### Exercise 1: Creating a new web site with Visual Studio 2015 ###

In this exercise, you'll create a new ASP.NET Core 1.0 Web Application project in Visual Studio 2015. You'll then explore the generated solution, and see it in action.

<a name="Ex1Task1" ></a>
#### Task 1 - Creating a site using the Web Application project template ####

In this task, you'll create a new Web site in Visual Studio based on the **ASP.NET Core 1.0 Web Application** project template.

1. Open **Visual Studio Community 2015** and select **File | New | Project...** to create a new solution.

1. In the **New Project** dialog box, select **ASP.NET Web Application** under the **Visual C# | Web** tab, and make sure **.NET Framework 4.6** is selected and **Add Azure Insights to project** is cleared. Name the project _MyWebApp_, choose a **Location** and click **OK**.

	![New ASP.NET Web Application project](Images/creating-new-aspnet-web-application-project.png?raw=true "New ASP.NET Web Application project")

	_Creating a new ASP.NET Web Application project_

1. In the **New ASP.NET Project** dialog box, select the **Web Application** template under **ASP.NET 5 Templates**. Also, make sure that **Host in the cloud** is cleared and the **Authentication** option is set to **Individual User Accounts**. Click **OK** to continue.

	![Creating a new project with the Web Application template](Images/creating-a-new-aspnet-project.png?raw=true "Creating a new project with the Web Application template")

	_Creating a new project with the Web Application template_

1. Once the project is created you can proceed to explore the generated solution.

	![Exploring the generated solution](Images/exploring-the-generated-solution.png?raw=true "Exploring the generated solution")

	_Exploring the generated solution_

1. The following is a brief description of the components you can find in the generated solution:

	* **global.json:** This file is used to configure the solution as a whole. It includes just two sections, projects and sdk by default.
	* **References**: This folder details the server-side references for the project which might be assemblies, NuGet packages, or other projects.
	* **wwwroot:** This special folder represents the actual root of the web application when running on a web server. Resources like images, script files and stylesheets are located inside this folder.
	* **Dependencies:** This section contains two subfolders: **Bower** and **NPM**. These folders correspond to two package managers by the same names and they’re used to pull in client-side dependencies and tools.
	* **Migrations:** This folder contains the Entity Framework migrations. This folder is added when the **Individual User Accounts** authentication option is selected during the configuration of the project template.
	* **Models:** This folder will contain the classes that represent your application data.
	* **Controllers**, **ViewModels**, **Views** and **Services**: These folders are related with **ASP.NET MVC** components. Except for the Controllers folder, these folders are added when the **Individual User Accounts** authentication option is selected during the configuration of the project template. You'll explore the MVC and Web API technologies in the next exercises.
	* **appsettings.json:** This file contains the configurations like connection strings and logging levels.
	* **gulpfile.js:** This file contains the Gulp tasks for the project.
	* **project.json:** This file is used to define the project’s server side dependencies, as well as other project-specific information.
	* **Startup.cs:** class file wires up configuration, MVC, EF, Identity services, logging, routes, and more. It provides a good example on how to configure the services used by your ASP.NET application.

1. Expand the **Dependencies** node and inside it the **Bower** node. Right-click jquery and notice that it's possible to uninstall or update a package through the context menu. This will automatically remove or update the package from the corresponding JSON file.

	![The Dependencies context menu](Images/dependencies-context-command.png?raw=true "The Dependencies context menu")

	_The Dependencies context menu_

1. Click **Manage Bower Packages...** to open the Bower Package Manager UI. Here, you can update your installed packages, remove them or install new packages. For more information about bower, you can check their site at [http://bower.io/](http://bower.io/).

	![The Bower package manager UI](Images/bower-package-manager-ui.png?raw=true "The Bower package manager UI")

	_The Bower package manager UI_

1. Open the **_Layout.cshtml** file located inside the _Views/Shared_ folder, to explore the layout of the page. This page is using a new Razor language feature in ASP.NET Core called [TagHelpers](https://docs.asp.net/en/latest/mvc/views/tag-helpers/intro.html). TagHelpers allow creating tags - or extending HTML tags - with server-side logic. Notice in the example below how that some of the the `link` tags include some additional attributes such as `aspnet-fallback-href`. The `link` TagHelper evaluates these on the server and creates JavaScript code which tests if CDN resources are unavailable and, if so, loads local copies of those files. These tags are wrapped in `environment` tags, which are evaluated on the server. The result of the environment tags below is that you will always load local resources when developing, but will attempt to leverage CDN resources in staging and production.

	````HTML
    <environment names="Development">
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
        <link rel="stylesheet" href="~/css/site.css" />
    </environment>
    <environment names="Staging,Production">
        <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.5/css/bootstrap.min.css"
              asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
              asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
        <link rel="stylesheet" href="~/css/site.min.css" asp-append-version="true" />
    </environment>
    ````

1. Open the **Startup.cs** file. In this class you'll find [the **Configure** method](https://docs.asp.net/en/latest/fundamentals/startup.html#the-configure-method), which is used to specify how the ASP.NET application will respond to individual HTTP requests.

	> **Note:** ASP.NET Core 1.0 assumes that no frameworks are being used unless you explicitly configure it in the **Configure** method. This enables you to have full control over the HTTP pipeline.

	![The Configure method](Images/configure-method.png?raw=true "The Configure method")

	_The Configure method_

1. At the end of the **Configure** method, you'll find the required code to map HTTP routes to **controllers**.

	<!-- mark:5-10 -->
	````C#
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // ...

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
	````

1. The [**ConfigureServices** method](https://docs.asp.net/en/latest/fundamentals/startup.html#the-configureservices-method) should be used to configure the services used by your application. You'll notice that ASP.NET Core 1.0 supports [Dependency Injection](https://docs.asp.net/en/latest/fundamentals/dependency-injection.html) natively.

	![The ConfigureServices method](Images/configureservices-method.png?raw=true "The ConfigureServices method")

	_The ConfigureServices method_

1. Open the **HomeController.cs** file in the **Controllers** folder. ASP.NET Core supports regular controllers (inheriting from the **Controller** base type) as well as POCO controllers (controllers which do not inherit from the **Controller** base type).

1. Press **F5** to build and run the solution.

	![Running the web site](Images/running-the-web-site.png?raw=true "Running the web site")

	_Running the web site_

<a name="Exercise2" ></a>
### Exercise 2: Working with Data ###

In this exercise, you'll take advantage of the ASP.NET Scaffolding framework provided by Visual Studio to create an ASP.NET MVC controller (and actions) and Razor views to perform CRUD operations, without writing a single line of code. The scaffolding process will use Entity Framework Code First to generate the data context and the database schema in the SQL database.

**About Entity Framework Code First**

Entity Framework (EF) is an object-relational mapper (ORM) that enables you to create data access applications by programming with a conceptual application model instead of programming directly using a relational storage schema.

The Entity Framework Code First modeling workflow allows you to use your own domain classes to represent the model that EF relies on when performing queries, change-tracking and updating functions. Using the Code First development workflow, you do not need to begin your application by creating a database or specifying a schema. Instead, you can write standard .NET classes that define the most appropriate domain model objects for your application, and Entity Framework will create the database for you.

> **Note:** You can learn more about Entity Framework [here](https://docs.efproject.net).

<a name="Ex2Task1" ></a>
#### Task 1 - Creating a New Model ####

The first step is to define a **Person** class which will be the model used by the scaffolding process to create the MVC controller and the views.

1. Open **Visual Studio Community 2015** and the **MyWebApp.sln** solution located in the **Source/Ex1/End** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. In **Solution Explorer**, right-click the **Models** folder of the **MyWebApp** project and select **Add | Class...**, name the file _Person.cs_ and click **Add**.

1. Replace the content of the **Person.cs** file with the following code. Press **CTRL + S** to save the changes.

	(Code Snippet - _IntroASPNETCore - Ex2 - PersonClass_)
	<!-- mark:1-11 -->
	````C#
    namespace MyWebApp.Models
    {
        public class Person
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
	````

1. In **Solution Explorer**, right-click the **MyWebApp** project and select **Build**, or press **CTRL + SHIFT + B** to build the project.

<a name="Ex2Task2" ></a>
#### Task 2 - Creating an MVC Controller ####

Now that the **Person** model has been created, you'll use ASP.NET MVC scaffolding with Entity Framework to create the CRUD controller, actions and views.

1. In **Solution Explorer**, right-click the **Controllers** folder of the **MyWebApp** project and select **Add | New Scaffolded Item...**.

1. In the **Add Scaffold** dialog box, select **MVC 6 Controller with views, using Entity Framework** and then click **Add.**

	![Selecting MVC 6 Controller with views and Entity Framework](Images/selecting-mvc-6-controller.png?raw=true "Selecting MVC 6 Controller with views and Entity Framework")

	_Selecting MVC 6 Controller with views and Entity Framework_

1. Select the **Use async controller actions** option and select **Person (MyWebApp.Models)** as the **Model class**. Under **Data context class**, click **New data context** button and name it _PeopleContext_.

	![Adding an MVC controller with scaffolding](Images/adding-an-mvc-controller-with-scaffolding.png?raw=true "Adding an MVC controller with scaffolding")

	_Adding an MVC controller with scaffolding_

1. Click **Add** to complete the process. Visual Studio will then generate the required controller, actions, data context and the Razor views associated with the default CRUD operations of the Person entity.

	![After creating the MVC controller with scaffolding](Images/after-creating-the-mvc-controller-with-scaffo.png?raw=true "After creating the MVC controller with scaffolding")

	_After creating the MVC controller with scaffolding_

1. Open the **PeopleController.cs** file in the **Controllers** folder. Notice that the CRUD action methods have been generated automatically.

	````C#
    // ...

    // POST: People/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(person);
    }

    // GET: People/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return HttpNotFound();
        }

        Person person = await _context.Person.SingleAsync(m => m.Id == id);
        if (person == null)
        {
            return HttpNotFound();
        }
        return View(person);
    }

    // ...
	````

	> **Note:** By selecting the **Use async controller actions** check box from the scaffolding options in the previous steps, Visual Studio generates asynchronous action methods for all actions that involve access to the Person data context. It's recommended that you use asynchronous action methods for long-running, non-CPU bound requests to avoid blocking the Web server from performing work while the request is being processed.

<a name="Ex2Task3" ></a>
#### Task 3 - Running the Solution ####

In this task, you'll run the solution again to verify the work done on the previous tasks. You will also add a new person and verify it was successfully saved to the database.

1. Press **F5** to run the solution.

1. Navigate to **/People** to see the list of people. Since the database is currently empty you'll see an empty list.

1. Explore the scaffolded views and actions. You can create a new Person, see its details, edit it and remove it.

	![Navigating to the scaffolded MVC views](Images/navigating-to-the-scaffolded-mvc-views.png?raw=true)

	_Navigating to the scaffolded MVC views_

1. Go back to Visual Studio and press **SHIFT + F5** to stop debugging.

<a name="Exercise3" ></a>
### Exercise 3: Unit testing your apps ###

Having a suite of automated tests is one of the best ways to ensure a software application does what its authors intended it to do. ASP.NET Core has been designed with testability in mind, so that creating unit tests for your applications is easier than ever before.

In this exercise, you'll add a test project to your solution and then run unit tests using Visual Studio.

<a name="Ex3Task1" ></a>
#### Task 1 - Creating the test project ####

A test project is just a class library with references to a test runner and the project being tested (also referred to as the System Under Test or SUT). It’s a good idea to organize your test projects in a separate folder from your SUT projects. We'll be using the open-source [xUnit testing tool](http://xunit.github.io/docs/getting-started-dnx.html) in this exercise.

In this task, you'll create a test project in an ASP.NET Core solution.

1. Open **Visual Studio Community 2015** and the **MyWebApp.sln** solution located in the **Source/Ex2/End** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. In **Solution Explorer**, right-click the **solution** root, select **Add | New Solution folder** and name the folder _test_.

1. In **Solution Explorer**, right-click the **test** folder, select **Add | New Project...** and to create a new project called **MyWebApp.UnitTests** using the **Class Library (Package)** project template.


	![MyWebApp.UnitTests class library project](Images/unit-test-class-library-project.png?raw=true "MyWebApp.UnitTests class library project")

	_MyWebApp.UnitTests class library project_

1. Delete the **Class1.cs** file from the new project.

1. Open the **project.json** file and replace the **net451** and **dotnet5.4** frameworks with **dnx451** and **dnxcore50**. After applying these changes, the **project.json** file should be similar to the following.

	````JSON
	{
	 "version": "1.0.0-*",
	 "description": "MyWebApp.UnitTests Class Library",
	 "authors": [ "" ],
	 "tags": [ "" ],
	 "projectUrl": "",
	 "licenseUrl": "",

	 "frameworks": {
		"dnx451": { },
		"dnxcore50": {
		  "dependencies": {
			 "Microsoft.CSharp": "4.0.1-beta-23516",
			 "System.Collections": "4.0.11-beta-23516",
			 "System.Linq": "4.0.1-beta-23516",
			 "System.Runtime": "4.0.21-beta-23516",
			 "System.Threading": "4.0.11-beta-23516"
		  }
		}
	 }
	}
	````

1. Add a reference to **xunit** and **xunit.runner.dnx**, version "2.1.0-*" for both packages and ensure they restore successfully. You can do this using the **NuGet Package Manager** or by adding them to the **dependencies** node of the **project.json** file.

	````
	"dependencies": {
	  "xunit": "2.1.0",
	  "xunit.runner.dnx": "2.1.0-*"
	}
	````

1. In **Solution Explorer**, right-click the **References** folder inside the **MyWebApp.UnitTests** and select **Add Reference...** to add the reference to the **MyWebApp** project. You can also do the same by adding the **MyWebApp** project in the **dependencies** node of the **project.json** file.

	````
	"dependencies": {
	  "MyWebApp": "1.0.0-*",
	  "xunit": "2.1.0",
	  "xunit.runner.dnx": "2.1.0-*"
	}
	````

1. Now, in the **project.json** file, add a new command named **test** with the value **xunit.runner.dnx** by adding the following node at the same level of the **dependencies** node.

	````
	"commands": {
	  "test": "xunit.runner.dnx"
	}
	````

1. The updated **project.json** file should look like the following code snippet.

	````
	{
	  "version": "1.0.0-*",
	  "description": "MyWebApp.UnitTests Class Library",
	  "authors": [ "" ],
	  "tags": [ "" ],
	  "projectUrl": "",
	  "licenseUrl": "",

	  "frameworks": {
		 "dnx451": { },
		 "dnxcore50": {
			"dependencies": {
			  "Microsoft.CSharp": "4.0.1-beta-23516",
			  "System.Collections": "4.0.11-beta-23516",
			  "System.Linq": "4.0.1-beta-23516",
			  "System.Runtime": "4.0.21-beta-23516",
			  "System.Threading": "4.0.11-beta-23516"
			}
		 }
	  },
	  "dependencies": {
		 "MyWebApp": "1.0.0-*",
		 "xunit": "2.1.0",
		 "xunit.runner.dnx": "2.1.0-*"
	  },
	  "commands": {
		 "test": "xunit.runner.dnx"
	  }
	}
	````

<a name="Ex3Task2" ></a>
#### Task 2 - Creating some Simple Tests ####

1. In **Solution Explorer**, right-click the **MyWebApp.UnitTests** project and select **Add | Class...**, name the file _MyTest.cs_ and click **Add**.

1. Add a method `public void MyFirstTest()` and decorate it with the `[Fact]` attribute, importing any required namespaces as you go.

1. Inside the **MyFirstTest** method, add a simple true assertion to have a passing test, e.g. `Assert.Equal(1, 1);`

	````C#
	[Fact]
	public void MyFirstTest()
	{
		Assert.Equal(1, 1);
	}
	````

1. Now, add a failing test. The class should look like the following code snippet.

	````C#
	using Xunit;

	namespace MyWebApp.UnitTests
	{
		 public class MyTest
		 {
			  [Fact]
			  public void MyFirstTest()
			  {
					Assert.Equal(1, 1);
			  }

			  [Fact]
			  public void MyFirstFailingTest()
			  {
					Assert.Equal(1, 2);
			  }
		 }
	}
	````

1. Open the **Test Explorer** window. To do this, go to **Test > Windows > Test Explorer**.

1. Build the solution and your tests should appear.

1. Run the test by pressing the **Run All** button in **Test Explorer**.

	![Results in Test Explorer](Images/results-in-test-explorer.png?raw=true "Results in Test Explorer")

	_Results in Test Explorer_

	> **Note:** If it bothers you, you can make that second test pass by changing from `Assert.Equal` to `Assert.NotEqual`.

<a name="Ex3Task3" ></a>
#### Task 3 - Testing a Controller Action ####

1. Next, we'll add a simple test for our `HomeController`. In **Solution Explorer**, right-click the **MyWebApp.UnitTests** project and select **Add | Class...**, name the file _HomeControllerTests.cs_ and click **Add**.

1. Add a method `public void HomeControllerIndexReturnsResponse()` and decorate it with the `[Fact]` attribute, importing any required namespaces as you go.

1. Update the **HomeControllerIndexReturnsResponse** method, adding the following code (using the Arrange / Act / Assert pattern):

	````C#
    using Microsoft.AspNet.Mvc;
    using MyWebApp.Controllers;
    using Xunit;
    
    namespace MyWebApp.UnitTests
    {
        public class HomeControllerTests
        {
            [Fact]
            public void HomeControllerIndexReturnsResponse() {
                // Arrange
                var controller = new HomeController();
    
                // Act
                var result = controller.Index() as ViewResult;
    
                // Assert
                Assert.NotNull(result);
            }
        }
    }	
	````

1. Re-run your tests in the Test Explorer and verify that your HomeController test passes.

	> **Note:** The previous tasks show you how to configure unit testing in an ASP.NET Core application, and how to create a simple test for a controller action. Unit testing is an important component of quality application development, and we encourage you to devote some time after this lab for some further study. Here are a few unit testing recommendations and resources:
    * While it’s useful to be able to test controller actions, we generally recommend that you focus your unit testing efforts on your application-specific code rather than MVC-specific functionality. For instance, rather than testing controller actions, it’s probably more useful to test application-specific logic and services.
    * ASP.NET Core and Entity Framework Core were both designed with testability in mind. ASP.NET Core and Entity Framework Core both have comprehensive support for dependency injection, and Entity Framework Core’s In-Memory Database support was created specifically to support unit testing.
    * For more in-depth information on unit testing with ASP.NET Core and Entity Framework Core, see the following docs:
        * [Unit Testing ASP.NET Core applications](https://docs.asp.net/en/latest/testing/unit-testing.html)
        * [Unit Testing Entity Framework with the InMemory provider](https://docs.efproject.net/en/latest/miscellaneous/testing.html)

<a name="Exercise4" ></a>
### Exercise 4: Cross-platform development ###

To appeal to a broader audience of developers, **ASP.NET Core 1.0** supports cross-platform development on Windows, Mac and Linux. The entire ASP.NET Core 1.0 stack is open source and encourages community contributions and engagement. ASP.NET Core 1.0 comes with a new, agile project system in Visual Studio while also providing a complete command-line interface so that you can develop using the tools of your choice.

In this exercise, you'll create a new project and run it in **Ubuntu** 14.04 using the terminal and **Visual Studio Code**. Full instructions for installing ASP.NET Core on all platforms are available [here](https://docs.asp.net/en/latest/getting-started/index.html).

<a name="Ex4Task1" ></a>
#### Task 1 - Creating the Ubuntu environment ####

> **IMPORTANT NOTE:** We've documented the necessary steps for creating an Ubuntu development environment, but if you're completing this Code Lab at Build 2016, we've already configured your development environment in a Hyper-V virtual machine. You can skim through Task 1 to understand what's involved, or just skip ahead to [Task 2 - Creating a ASP.NET Core 1.0 application using Yeoman](#Ex4Task2).

In this task, you'll set up your **Ubuntu** 14.04 environment by installing **ASP.NET Core 1.0** dependencies, as well as **Visual Studio Code**, **Yeoman** and the **ASP.NET generator**.

1. Install the dependencies for the **.NET Version Manager (DNVM)** by executing the following commands in a terminal.

	````
	sudo apt-get update
	sudo apt-get install -y unzip curl
	````

1. Now download and install the **.NET Version Manager (DNVM)** by executing the following command in a terminal.

	````
	curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
	````

1. After **dnvm** is installed, install the dependencies for **DNX** by executing the following command in a terminal.

	````
	sudo apt-get install -y libunwind8 gettext libssl-dev libcurl4-openssl-dev zlib1g libicu-dev uuid-dev
	````

1. Use **dvnm** to install **DNX** for .net core by executing the following command in a terminal.

	````
	dnvm upgrade -r coreclr
	````

1. **Libuv** is a multi-platform asynchronous IO library that is used by Kestrel, a cross-platform HTTP server for hosting ASP.NET Core web applications. Install **libuv** by executing the following commands in a terminal.

	````
	sudo apt-get install -y make automake libtool curl
	curl -sSL https://github.com/libuv/libuv/archive/v1.8.0.tar.gz | sudo tar zxfv - -C /usr/local/src
	cd /usr/local/src/libuv-1.8.0
	sudo sh autogen.sh
	sudo ./configure
	sudo make
	sudo make install
	sudo rm -rf /usr/local/src/libuv-1.8.0 && cd ~/
	sudo ldconfig
	````

1. **OmniSharp** requires **Mono**, to install it execute the following commands in a terminal.

	````
	sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
	echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
	sudo apt-get update
	sudo apt-get install -y mono-complete
	````

1. Navigate to [https://code.visualstudio.com/](https://code.visualstudio.com/), download **Visual Studio Code** for Linux.

1. Create a new folder and extract the content of the downloaded zip inside that folder. To run **Visual Studio Code**, double-click **Code**.

	> **Note:** If you want to run VS Code from the terminal, create the following link substituting **/path/to/vscode/Code** with the absolute path to the Code executable.

	> ````
	sudo ln -s /path/to/vscode/Code /usr/local/bin/code
	> ````

1. In order to install **node.js** and **npm**, add the NodeSource Debian and Ubuntu binary distributions repository by executing the following command in a terminal.

	````
	curl -sL https://deb.nodesource.com/setup_4.x | sudo -E bash -
	````

1. Install **node.js** and **npm** by executing the following command in a terminal.

	````
	sudo apt-get install -y nodejs
	````

1. Now, install **Yeoman** and the **ASP.NET generator** using npm by executing the following command in a terminal.

	````
	sudo npm install -g yo generator-aspnet
	````

<a name="Ex4Task2" ></a>
#### Task 2 - Creating a ASP.NET Core 1.0 application using Yeoman ####

**Yeoman** helps you to kickstart new projects, prescribing best practices and tools to help you stay productive.

To do so, it provides a generator ecosystem. A generator is basically a plugin that can be run with the `yo` command to scaffold complete projects or useful parts. By creating the **ASP.NET Core 1.0** generator, the goal is to provide an experience consistent with creating new ASP.NET Core projects and files in Visual Studio 2015.

In this task, you'll create a **ASP.NET Core 1.0** web application using **Yeoman** and the **ASP.NET generator**.

1. Open a terminal and run the following command.

	````
	yo aspnet
	````

	![Running Yeoman ASP.NET generator](Images/running-yeoman-aspnet.png?raw=true "Running Yeoman ASP.NET generator")

	_Running Yeoman ASP.NET generator_

1. Select the **Web Application** option.

1. Next, you'll be prompted to name your application. Change the default name to use _MyWebApp_.

	````
	? What's the name of your ASP.NET application? (WebApplication)
	````

1. On proceeding, the generator will create an application similar to the one created in **Windows** with **Visual Studio**. If you execute the **tree** command you'll see an output similar to the following.

	````
	.
	├─── Controllers
	├─── Migrations
	├─── Models
	├─── Services
	├─── ViewModels
	│    ├─── Account
	│    └─── Manage
	├─── Views
	│    ├─── Account
	│    ├─── Home
	│    ├─── Manage
	│    └─── Shared
	└─── wwwroot
		  ├─── css
		  ├─── images
		  └─── js

	16 directories, 72 files
	````

1. Restore the dependencies running the following commands in the terminal.

	````
	cd "MyWebApp"
	dnu restore
	````

<a name="Ex4Task3" ></a>
#### Task 3 - Opening the site in VS Code ####

**Visual Studio Code** is a code editor redefined and optimized for building and debugging modern web and cloud applications. Additionally, it's free and available on your favorite platform - Linux, Mac OSX, and Windows.

In this task, you'll open and run the generated **ASP.NET Core 1.0** web application using **Visual Studio Code**.

1. Open Visual Studio Code and select **File > Open Folder...** in the top menu to open the folder where you generated the project. When VS Code sees the project.json it will load it.

1. Open the **Startup.cs** file and explore the different features that VS Code gives you like **IntelliSense** or features that traditionally found only in IDEs, such as **Outlining**, **Find All References**, and **Go To Definition**.

	![Exploring the VS Code features](Images/exploring-vs-code-features.png?raw=true "Exploring the VS Code features")

	_Exploring the VS Code features_

1. Open the **project.json** file and locate the **commands** node. you'll find two commands: **web** and **ef**.

	````
	"commands": {
	  "web": "Microsoft.AspNet.Server.Kestrel",
	  "ef": "EntityFramework.Commands"
	}
	````

1. To execute the available commands, right-click the **project.json** file and select **Open in Terminal** to open a terminal where the file is located.

1. Next, run the Web site by executing the **dnx web** command in the terminal.

1. Open your favorite browser and browse to **http://localhost:5000** to browse the site created.

	![Browsing the site](Images/browsing-the-site.png?raw=true "Browsing the site")

	_Browsing the site_

> **Note** : For RC2 and following, the dnvm / dnx / dnu toolchain will be changed to use a `dotnet` based CLI.

---

<a name="Summary" ></a>
## Summary ##

By completing this module, you should have:

- Created a Web site based on the **ASP.NET Core 1.0** template
- Identified the main components of an **ASP.NET Core 1.0** application
- Worked with data in an **ASP.NET Core 1.0** application
- Created a unit test project
- Created and ran a **ASP.NET Core 1.0** application in Ubuntu

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.
