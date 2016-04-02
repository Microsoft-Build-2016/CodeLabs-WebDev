<a name="HOLTop" ></a>
# ASP.NET Core 1.0 Internals #

---

<a name="Overview" ></a>
## Overview ##

ASP.NET Core 1.0 is a significant redesign of ASP.NET. For example, in ASP.NET Core you compose your request pipeline using Middleware. ASP.NET Core middleware perform asynchronous logic on an HttpContext and then optionally invoke the next middleware in the sequence or terminate the request directly. You generally _Use_ middleware by invoking a corresponding extension method on the IApplicationBuilder in your Configure method. Examples of middleware components can be routing and authentication.

In this module, you'll explore some of the ASP.NET Core 1.0 features including how to work with middleware components and even create a custom one.

<a name="Objectives"></a>
### Objectives ###
In this module, you'll see how to:

- Work with static files
- Work with routing
- Write custom middleware
- Add Authentication to your web applications

<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this module:

- [Visual Studio Community 2015][1] or greater
- [ASP.NET Core 1.0][2]

[1]: https://www.visualstudio.com/products/visual-studio-community-vs
[2]: https://get.asp.net

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.

<a name="Setup"></a>
### Setup ###
In order to run the exercises in this module, you'll need to set up your environment first.

1. Open Windows Explorer and browse to the module's **Source** folder.
1. Right-click **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this module.
1. If the User Account Control dialog box is shown, confirm the action to proceed.

> **Note:** Make sure you've checked all the dependencies for this module before running the setup.

<a name="CodeSnippets"></a>
### Using the Code Snippets ###

Throughout the module document, you'll be instructed to insert code blocks. For your convenience, most of this code is provided as Visual Studio Code Snippets, which you can access from within Visual Studio 2015 to avoid having to add it manually.

>**Note**: Each exercise is accompanied by a starting solution located in the **Begin** folder of the exercise that allows you to follow each exercise independently of the others. Please be aware that the code snippets that are added during an exercise are missing from these starting solutions and may not work until you've completed the exercise. Inside the source code for an exercise, you'll also find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the corresponding exercise. You can use these solutions as guidance if you need additional help as you work through this module.

---

<a name="Exercises"></a>
## Exercises ##
This module includes the following exercises:

1. [Working with static files](#Exercise1)
1. [Introduction to Routing & MVC](#Exercise2)
1. [Building a middleware class](#Exercise3)
1. [Adding Authentication to your web applications](#Exercise4)

Estimated time to complete this module: **60 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this module describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1"></a>
### Exercise 1: Working with static files ###

Static files, which include HTML files, CSS files, image files, and JavaScript files, are assets that the app will serve directly to clients.

In this exercise, you'll configure your project to serve static files.

<a name="Ex1Task1"></a>
#### Task 1 - Serving static files ####

In order for static files to be served, you must configure the _Middleware_ to add static files to the pipeline. This is accomplished by calling the **UseStaticFiles** extension method from **Startup.Configure** method.

In this task, you'll create an empty ASP.NET Core 1.0 project and configure it to serve static files.

1. Open **Visual Studio Community 2015** and select **File | New Project...** to start a new solution.

1. In the **New Project** dialog box, select **ASP.NET Web Application** under the **Visual C# | Web** tab, and make sure **.NET Framework 4.6** is selected. Name the project _MyWebApp_, choose a **Location** and click **OK**.

	![New ASP.NET Web Application project](Images/creating-new-aspnet-web-application-project.png?raw=true "New ASP.NET Web Application project")

	_Creating a new ASP.NET Web Application project_

1. In the **New ASP.NET Project** dialog box, select the **Empty** template under **ASP.NET 5 Templates**. Click **OK**.

	![Creating a new project with the ASP.NET Core Empty template](Images/creating-a-new-empty-project.png?raw=true "Creating a new project with the ASP.NET Core Empty template")

	_Creating a new project with the ASP.NET Core Empty template_

1. Add the **Microsoft.AspNet.StaticFiles** package as a dependency to **project.json**.

	````JSON
	"dependencies": {
	  "Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
	  "Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
	  "Microsoft.AspNet.StaticFiles": "1.0.0-rc1-final"
	},
	````

1. Open the **Startup.cs** file and add the **UseStaticFiles** method call in the **Configure** method before the hello world middleware.

	<!-- mark:5 -->
	````C#
    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.UseStaticFiles();

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
    }
	````

1. Create a file called **index.html** with the following contents in the **wwwroot** folder.

	(Code Snippet - _ASPNETCore - Ex1 - IndexHtml_)
	<!-- mark:1-10 -->
	````HTML
	<!DOCTYPE html>
	<html>
	<head>
		 <meta charset="utf-8" />
		 <title>Hello static world!</title>
	</head>
	<body>
		 <h1>Hello from ASP.NET Core!</h1>
	</body>
	</html>
	````

1. Run the application and navigate to the root. It should show the hello world middleware.

	![Hello World](Images/hello-world.png?raw=true "Hello World")

	_Hello World_

1. Navigate to **index.html** and it should show the static page in **wwwroot**.

	![Hello World static](Images/hello-world-aspnet-core.png?raw=true "Hello World static")

	_Hello World static_

<a name="Ex1Task2" ></a>
#### Task 2 - Adding default document support ####

In order for your Web app to serve a default page without the user having to fully qualify the URI there is a **UseDefaultFiles** extension method that can be used. This method is a _URL re-writer_ that doesn’t actually serve the file.

In addition to the **UseStaticFiles** and **UseDefaultFiles** extensions methods, there is also a single method - **UseFileServer** - that combines the functionality of these two methods as well as the **UseDirectoryBrowser** extensions methods.

In this task, you'll use the **UseFileServer** to enable serving both, static and default files.

1. Open the **Startup.cs** file and change the static files middleware in the **Configure** method from `app.UseStaticFiles()` to `app.UseFileServer()`.

	<!-- mark:5 -->
	````C#
    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.UseFileServer();

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
    }
	````

1. Run the application again. The default page **index.html** should be shown when navigating to the root of the site.

<a name="Exercise2" ></a>
### Exercise 2: Introduction to Routing & MVC ###

A route is a URL pattern that is mapped to a handler. The handler can be a physical file, such as an .aspx file in a Web Forms application. A handler can also be a class that processes the request, such as a controller in an MVC application.

ASP.NET routing enables you to use URLs that do not have to map to specific files in a Web site. Because the URL does not have to map to a file, you can use URLs that are descriptive of the user's action and therefore are more easily understood by users.

In this exercise, you'll learn how to configure routing in your application.

<a name="Ex2Task1" ></a>
#### Task 1 - Adding MVC ####

ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and that gives you full control over markup for enjoyable, agile development. ASP.NET MVC includes many features that enable fast, TDD-friendly development for creating sophisticated applications that use the latest web standards.

In this task, you'll configure the project to use ASP.NET MVC and configure a sample route.

1. Open **Visual Studio Community 2015** and the **MyWebApp.sln** solution located in the **Source/Ex1/End** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. Open the **project.json** file and add **Microsoft.AspNet.Mvc** to the **dependencies** section.

	````JSON
	"dependencies": {
		"Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
		"Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
		"Microsoft.AspNet.StaticFiles": "1.0.0-rc1-final",
		"Microsoft.AspNet.Mvc": "6.0.0-rc1-final"
	},
	````

1. In **Solution Explorer**, right-click the **MyWebApp** project and select **Add | New Folder** and name the folder _Controllers_.

1. Right-click the new folder and select **Add | New Item...**, select **MVC Controller Class**, name the file _HomeController.cs_ and click **Add**.

1. Replace the content of the file with the following code snippet.

	(Code Snippet - _ASPNETCore - Ex2 - HomeController_)
	<!-- mark:1-10 -->
	````C#
	namespace MyWebApp.Controllers
	{
		 using Microsoft.AspNet.Mvc;

		 public class HomeController : Controller
		 {
			  [HttpGet()]
			  public string Index() => "Hello from MVC!";
		 }
	}
	````

1. Now, open the **Startup.cs** file and add the MVC services and middleware to the configuration, adding `services.AddMvc()` and replacing the `app.Run` method call in the **Configure** method with the `UseMvc` method as shown in the following code snippet.

	<!-- mark:3,13-18 -->
	````C#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.UseFileServer();

        app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
    }
	````

1. Run the site and verify the message is returned from your MVC controller by navigating to the **/home** endpoint.

	> **Note:** ASP.NET Core MVC also includes a handy new utility method, `app.UseMvcWithDefaultRoute` so you don't have to remember that template string.

<a name="Exercise3" ></a>
### Exercise 3: Writing custom middleware ###

Small application components that can be incorporated into an HTTP request pipeline are known collectively as middleware. ASP.NET Core 1.0 has integrated support for middleware, which are wired up in an application's **Configure** method during _Application Startup_.

In this exercise, you'll create a middleware class that sets the current culture based on a query string value.

> **Note:** We're using localization related middleware in this exercise as an example scenario, but in most application's you'd use [ASP.NET Core's built-in support localization support](https://docs.asp.net/en/latest/fundamentals/localization.html).

<a name="Ex3Task1" ></a>
#### Task 1 - Writing a middleware class that sets the current culture based on a query string value ####

Middleware are components that are assembled into an application pipeline to handle requests and responses. Each component can choose whether to pass the request on to the next component in the pipeline, and can perform certain actions before and after the next component in the pipeline. Request delegates are used to build this request pipeline, which are then used to handle each HTTP request to your application.

Request delegates are configured using **Run**, **Map**, and **Use** extension methods on the **IApplicationBuilder** type that is passed into the **Configure** method in the **Startup** class. An individual request delegate can be specified in-line as an anonymous method, or it can be defined in a reusable class. These reusable classes are middleware, or middleware components. Each middleware component in the request pipeline is responsible for invoking the next component in the chain, or choosing to short-circuit the chain if appropriate.

In this task, you'll create inline middleware.

1. Open **Visual Studio Community 2015** and select **File | New Project...** to start a new solution using the **ASP.NET Web Application** template, name it _MiddlewareApp_, click **OK** and then select the **Empty** template under **ASP.NET 5 Templates**.

1. Open the **Startup.cs** file and replace the content of the **Configure** method with the following code snippet which creates an inline middleware that runs **before** the hello world delegate that sets the culture for the current request from the query string.

	(Code Snippet - _ASPNETCore - Ex3 - InlineMiddleware_)
	<!-- mark:3-27 -->
	````C#
    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.Use((context, next) =>
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);
#if !DNXCORE50
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
#else
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
#endif
            }

            // Call the next delegate/middleware in the pipeline
            return next();
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
        });
    }
	````

1. Resolve the missing using statements.

1. Run the application. To see the middleware in action, set the culture by adding the **culture** query string, e.g. _http://localhost:64165/?culture=no_

<a name="Ex3Task2" ></a>
#### Task 2 - Moving the middleware to its own type ####

In this task you'll move the middleware to a separated file.

1. Right-click the **MiddlewareApp** project and select **Add | Class...**, name the file _RequestCultureMiddleware.cs_ and click **Add**.

1. Add a constructor that takes a **RequestDelegate** parameter and assigns it to a private field using the following code snippet. Keep resolving the missing using statements whenever you need to.

	(Code Snippet - _ASPNETCore - Ex3 - RequestCultureMiddlewareClass_)
	<!-- mark:3-8 -->
	````C#
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
    }
	````

1. Add the following method with the content of the inline middleware delegate you previously added to the **Startup.cs** file.

	(Code Snippet - _ASPNETCore - Ex3 - RequestCultureMiddlewareInvokeMethod_)
	<!-- mark:1-18 -->
	````C#
    public Task Invoke(HttpContext context)
    {
        var cultureQuery = context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            var culture = new CultureInfo(cultureQuery);
#if !DNXCORE50
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
#else
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
#endif
        }

        // Call the next delegate/middleware in the pipeline
        return this.next(context);
    }
	````

1. At the bottom of the file, add a class that exposes the middleware via an extension method on **IApplicationBuilder**.

	(Code Snippet - _ASPNETCore - Ex3 - RequestCultureMiddlewareExtensionsClass_)
	<!-- mark:1-7 -->
	```C#
	public static class RequestCultureMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestCultureMiddleware>();
		}
	}
	```

1. Back in the application's **Startup.cs** file, replace the inline middleware delegate with the call to the `app.UseRequestCulture()` method to add your new middleware class to the HTTP pipeline. When you're done, your `Configure` method should look like the code below:

	<!-- mark:1 -->
	``` C#
    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.UseRequestCulture();

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
        });

    }
	```

1. Run the application and verify that the middleware is now running as a class.

<a name="Ex3Task3" ></a>
#### Task 3 - Adding options to middleware ####

In this task, you'll update the **RequestCultureMiddleware** implementation to support setting a default culture as a configuration value.

1. Right-click the **MiddlewareApp** project and select **Add | Class...**, name the file _RequestCultureOptions.cs_ and click **Add**.

1. In the new class, add a property named **DefaultCulture** with **CultureInfo** as type, resolving the missing dependency.

	<!-- mark:3-3 -->
	````C#
	public class RequestCultureOptions
	{
		public CultureInfo DefaultCulture { get; set; }
	}
	````

1. Open the _RequestCultureMiddleware.cs_ file and update the **RequestCultureMiddleware** constructor to take the **RequestCultureOptions** parameter as is shown in the following code snippet.

	<!-- mark:4,6,9 -->
	````C#
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate next;
        private readonly RequestCultureOptions options;

        public RequestCultureMiddleware(RequestDelegate next, RequestCultureOptions options)
        {
            this.next = next;
            this.options = options;
        }

        //...
	}
	````

1. Update the **Invoke** method of the middleware to use the **DefaultCulture** property from **options** if none was specified on the query string as shown in the following code snippet.

	(Code Snippet - _ASPNETCore - Ex3 - InvokeMethodWithDefaultCulture_)
	<!-- mark:1-27 -->
	````C#
    public Task Invoke(HttpContext context)
    {
        CultureInfo requestCulture = null;

        var cultureQuery = context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            requestCulture = new CultureInfo(cultureQuery);
        }
        else
        {
            requestCulture = this.options.DefaultCulture;
        }

        if (requestCulture != null)
        {
#if !DNXCORE50
            Thread.CurrentThread.CurrentCulture = requestCulture;
            Thread.CurrentThread.CurrentUICulture = requestCulture;
#else
            CultureInfo.CurrentCulture = requestCulture;
            CultureInfo.CurrentUICulture = requestCulture;
#endif
        }

        return this.next(context);
    }
	````

1. In the same file, replace the **RequestCultureMiddlewareExtensions** class implementation with the following code snippet which adds an overload to the **UseRequestCulture** method that takes the **RequestCultureOptions** and passes them into the `UseMiddleware<RequestCultureMiddleware>` call.

	(Code Snippet - _ASPNETCore - Ex3 - UpdatedRequestCultureMiddlewareExtensions_)
	<!-- mark:1-9 -->
	````C#
	public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
	{
		return builder.UseRequestCulture(new RequestCultureOptions());
	}

	public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder, RequestCultureOptions options)
	{
		return builder.UseMiddleware<RequestCultureMiddleware>(options);
	}
	````

1. Open the _Startup.cs_ file and set the fallback culture in the **Configure** method to some default value, e.g. _"en-GB"_.

	(Code Snippet - _ASPNETCore - Ex3 - UpdatedUseRequestCulture_)
	<!-- mark:1-4 -->
	````C#
	app.UseRequestCulture(new RequestCultureOptions
	{
		 DefaultCulture = new CultureInfo("en-GB")
	});
	````

1. Run the application and verify that the default culture when no query string is specified matches the one configured.

<a name="Ex3Task4" ></a>
#### Task 4 - Reading request culture configuration from a file ####

ASP.NET Core’s configuration system has been re-architected from previous versions of ASP.NET, which relied on **System.Configuration** and XML configuration files like **web.config**. The new configuration model provides streamlined access to key/value based settings that can be retrieved from a variety of providers. Applications and frameworks can then access configured settings using the new **Options** pattern.

In this task, you'll use the new **Configuration** system loading the default culture value of **RequestCultureOptions** from a JSON file.

1. Open the _Startup.cs_ file and add a new private class field named **configuration** of type **IConfiguration**, resolving the missing dependency for **IConfiguration**.

	<!-- mark:3 -->
	````C#
    public class Startup
    {
        private readonly IConfiguration configuration;

        // ...
    }
	````

1. Add a new constructor, create a new **Configuration** object in the constructor using the **ConfigurationBuilder** and assign it to the configuration class field that you created in the previous step.

	(Code Snippet - _ASPNETCore - Ex3 - StartupConstructor_)
	<!-- mark:1-7 -->
	````C#
    public Startup()
    {
        var configuration = new ConfigurationBuilder()
            .Build();

        this.configuration = configuration;
    }
	````

1. Open the _project.json_ file and add a reference to the **Microsoft.Extensions.Configuration.Json** package in the **dependencies** node.

	<!-- mark:4 -->
	````JSON
	"dependencies": {
	  "Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
	  "Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
	  "Microsoft.Extensions.Configuration.Json": "1.0.0-rc1-final"
	},
	````

1. Back in the _Startup.cs_ file, add a call to `.AddJsonFile("config.json")` immediately after the creation of the **ConfigurationBuilder** object as a chained method.

	<!-- mark:8 -->
	````C#
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            this.configuration = configuration;
        }

		// ...
	}
	````

1. Right-click the **MiddlewareApp** project and select **Add | New Item...**, select **JSON file** as template, name the file _config.json_ and click **Add**.

1. In the new _config.json_ file, add a new key/value pair `"culture": "en-US"`.

	````JSON
	{
	  "culture": "en-US"
	}
	````

1. Open the _Startup.cs_ file and update the code to set the default culture using the new configuration system.

	````C#
	app.UseRequestCulture(new RequestCultureOptions
	{
		 DefaultCulture = new CultureInfo(this.configuration["culture"] ?? "en-GB")
	});
	````

1. Run the application and validate that the default culture is the one in the configured in the configuration file.

1. Update the culture value to "es" in the _config.json_ file and refresh the page (without changing any other code). Note that the message hasn't changed as the configuration was only read when the application was started.

1. Go back to Visual Studio and restart the web server by pressing **Ctrl + Shift + F5**.

1. Go back to the browser and refresh the page; it should show the updated message.

<a name="Ex3Task5" ></a>
#### Task 5 - Flowing options from dependency injection system to middleware ####

ASP.NET Core is designed from the ground up to support and leverage dependency injection. ASP.NET Core applications can leverage built-in framework services by having them injected into methods in the Startup class, and application services can be configured for injection as well. The default services container provided by ASP.NET Core provides a minimal feature set and is not intended to replace other containers.

In this task you'll use the dependency injection system to configure the **RequestCultureMiddleware** options.

1. Open the _project.json_ file and add a reference to the **Microsoft.Extensions.OptionsModel** package in the **dependencies** node.

	````JSON
	"dependencies": {
	  "Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
	  "Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
	  "Microsoft.Extensions.Configuration.Json": "1.0.0-rc1-final",
	  "Microsoft.Extensions.OptionsModel": "1.0.0-rc1-final"
	},
	````

1. Change the **RequestCultureMiddleware** constructor to take `IOptions<RequestCultureOptions>` instead of `RequestCultureOptions` and obtain the value of the options parameter. Resolve the missing dependencies.

	````C#
	public RequestCultureMiddleware(RequestDelegate next, IOptions<RequestCultureOptions> options)
	{
		this.next = next;
		options = options.Value;
	}
	````

1. Update the **RequestCultureMiddlewareExtensions** class removing the method with the options parameter and calling `UseMiddleware<RequestCultureMiddleware>` in the other method as shown in the following code snippet.

	````C#
	public static class RequestCultureMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
		{
			 return builder.UseMiddleware<RequestCultureMiddleware>();
		}
	}
	````

1. In _Startup.cs_ change the **UseRequestCulture** middleware to not take any arguments.

	````C#
	app.UseRequestCulture();
	````

1. In the **ConfigureServices** method located in the same file, add a line that configures the culture using the `services.Configure<RequestCultureOptions>` method and also add a call to the **AddOptions** method as shown in the following code snippet.

	(Code Snippet - _ASPNETCore - Ex3 - ConfigureServices_)
	<!-- mark:3-9 -->
	````C#
    public void ConfigureServices(IServiceCollection services)
    {
        // Setup options with DI
        services.AddOptions();

        services.Configure<RequestCultureOptions>(options =>
        {
            options.DefaultCulture = new CultureInfo(this.configuration["culture"] ?? "en-GB");
        });
    }
	````

1. Run the application and verify that options are now being configured from the dependency injection system.

<a name="Exercise4" ></a>
### Exercise 4: Adding Authentication to your web applications ###

**ASP.NET Identity** is a membership system which allows you to add login functionality to your application. Users can create an account and login with a user name and password or they can use an external login provider such as Facebook, Google, Microsoft Account, Twitter and more.

In this exercise, you'll walk through the default configuration of the ASP.NET Core project templates that uses ASP.NET Identity as well as configure **Facebook** as an external login provider in your application.

<a name="Ex4Task1" ></a>
#### Task 1 - Introduction to ASP.NET Identity ####

In this task, you'll learn how the ASP.NET Core project templates use ASP.NET Identity to add functionality to register, log in, and log out a user.

1. Open **Visual Studio Community 2015** and select **File | New | Project...** to create a new solution.

1. In the **New Project** dialog box, select **ASP.NET Web Application** under the **Visual C# | Web** tab, and make sure **.NET Framework 4.6** is selected. Name the project _MyWebApp_, choose a **Location** and click **OK**.

	![New ASP.NET Web Application project](Images/creating-new-aspnet-web-application-project.png?raw=true "New ASP.NET Web Application project")

	_Creating a new ASP.NET Web Application project_

1. In the **New ASP.NET Project** dialog box, select the **Web Application** template under **ASP.NET 5 Templates**. Also, make sure that the **Authentication** option is set to **Individual User Accounts**. Click **OK** to continue.

	![Creating a new project with the Web Application template](Images/creating-a-new-aspnet-project.png?raw=true "Creating a new project with the Web Application template")

	_Creating a new project with the Web Application template_

1. Once the project is created, open the _project.json_ file and locate the _Microsoft.AspNet.Identity.EntityFramework_ package. This package has the **Entity Framework** implementation of **ASP.NET Identity** which will persist the ASP.NET Identity data and schema to SQL Server.

	![The Microsoft.AspNet.Identity.EntityFramework package](Images/the-identity-package.png?raw=true "The Microsoft.AspNet.Identity.EntityFramework package")

	_The Microsoft.AspNet.Identity.EntityFramework package_

1. Expand the References node in Solution Explorer and then expand the _Microsoft.AspNet.Identity.EntityFramework_ package inside _DNX 4.5.1_. Note that it depends on _Microsoft.AspNet.Identity_ which is the primary reference assembly for the ASP.NET Identity system. This assembly contains the core set of interfaces for ASP.NET Identity.

	![The Microsoft.AspNet.Identity.EntityFramework dependencies](Images/the-identity-package-dependencies.png?raw=true "The Microsoft.AspNet.Identity.EntityFramework package dependencies")

	_The Microsoft.AspNet.Identity.EntityFramework package dependencies_

1. Open the _Startup.cs_ file and locate the **ConfigureServices** method. In this method, the Identity services are configured by the following code.

	````C#
	public void ConfigureServices(IServiceCollection services)
	{
		 // ...

		 services.AddIdentity<ApplicationUser, IdentityRole>()
			  .AddEntityFrameworkStores<ApplicationDbContext>()
			  .AddDefaultTokenProviders();

		 // ...
	}
	````

1. In the same file, locate the **Configure** method which will be called after the **ConfigureServices** method is called during the startup execution flow. In this method, **ASP.NET Identity** is enabled for the application when the **UseIdentity** method is called. This adds cookie-based authentication to the request pipeline.

	````C#
	public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
	{
		 // ...

		 app.UseIdentity();

		 // ...
	}
	````

1. Open the _AccountController.cs_ file located at the **Controllers** folder and locate the **Register** action with the **HttpPost** attribute. This action calls the **UserManager** service to create and sign in the user based on the **RegisterViewModel** information.

	````C#
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // ...

                await _signInManager.SignInAsync(user, isPersistent: false);

                // ...
	````

1. Locate the **Login** action with the **HttpPost** attribute. This action signs in the user using the **PasswordSignInAsync** method of the **SignInManager** service.

	````C#
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // ...
	````

1. Now, locate the **LogOff** action. This action calls the **SignOutAsync** method of the **SignInManager** service which clears the user's claims stored in a cookie.

	````C#
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation(4, "User logged out.");
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
	````

1. Run the solution and create a new user by clicking on **Register** to see the **ASP.NET Identity** system in action. You can debug the different actions in the **AccountController**.

	![Account register view](Images/account-register-view.png?raw=true "Account register view")

	_Account register view_

1. After you register your first user, you'll notice an error message suggesting that you apply existing migrations. Click **Apply Migrations**. You will now see that you're logged in as the new user.

1. Stop the application and explore the database by navigating to the **(localdb)MSSQLLocalDB/Databases/aspnet5-MyWebApp-<guid>/Tables** in the **SQL Server Object Explorer** view. Right-click the **dbo.AspNetUsers** table and select **View Data** to see the properties of the user you created.

	![Viewing the User Data in SQL Server Object Explorer](Images/viewing-user-data-in-sql-server-explorer.png?raw=true "Viewing the User Data in SQL Server Object Explorer")

	_Viewing the User Data in SQL Server Object Explorer_

<a name="Ex4Task2" ></a>
#### Task 2 - Enabling authentication using external providers ####

ASP.NET Core supports log in using OAuth 2.0 with credentials from an external authentication provider, such as Facebook, Twitter, LinkedIn, Microsoft, or Google. Enabling social login credentials in your web sites provides a significant advantage because millions of users already have accounts with these external providers. These users may be more inclined to sign up for your site if they do not have to create and remember a new set of credentials.

In this task, you'll create a Facebook app and configure your Web Application project to enables users to log in with their Facebook account as external provider.

1. In your browser, navigate to [https://developers.facebook.com/apps](https://developers.facebook.com/apps) and log in by entering your Facebook credentials. If you aren’t already registered as a Facebook developer, click **Register as a Developer** and follow the directions to register.

1. On the **Facebook for developers**' home page, add a new app by clicking on **Add a New App** and select **Website** from the platform choices.

1. On the **Quick Start for Website** page, select **Skip and Create App ID**.

1. Set a display name, e.g. _ASP.NET Social Logins_, and choose a Category, e.g. _Business_, and then press **Create App ID**.

1. On the **Basic** section of the **Settings** page, click **Add Platform** to specify that you're adding a website application.

1. Select **Website** from the platform choices, add your site URL (e.g. _https://localhost:44300/_) and click below on **Save Changes**.

1. Make a note of your **App ID** and your **App Secret** so that you can add both into your ASP.NET Core Web site later.

1. Switch back to **Visual Studio**, right-click the **MyWebApp** project and select **Manage User Secrets**.

	![Selecting Manage User Secrets](Images/selecting-manage-user-secrets.png?raw=true "Selecting Manage User Secrets")

	_Selecting Manage User Secrets_

1. In the _secrets.json_ file add the following code, replacing the placeholders with the values you got from **Facebook**.

	````JSON
	{
	  "Authentication": {
		 "Facebook": {
			"AppId": "<your-app-id>",
			"AppSecret": "<your-app-secret>"
		 }
	  }
	}
	````

1. Open the _project.json_ file and add the **Microsoft.AspNet.Authentication.Facebook** package as dependency

	````JSON
  "dependencies": {
		...
		"Microsoft.AspNet.Authentication.Facebook":  "1.0.0-rc1-final"
  },
	````

1. Open the _startup.cs_ file and add the Facebook middleware in the **Configure** method as shown in the following code snippet.

	(Code Snippet - _ASPNETCore - Ex4 - UseFacebookAuthentication_)
	<!-- mark:7-11 -->
	````C#
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // ...

        app.UseIdentity();

        app.UseFacebookAuthentication(options =>
        {
            options.AppId = Configuration["Authentication:Facebook:AppId"];
            options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
        });

        // ...
    }
	````

1. Run the application and navigate to the **Log in** page where you'll see the **Facebook** button.

	![Log in page with Facebook button](Images/log-in-page-with-facebook.png?raw=true "SLog in page with Facebook button")

	_Log in page with Facebook button_

---

<a name="Summary" ></a>
## Summary ##

By completing this module, you should have:

- Configured static files in your site
- Configured routing using MVC
- Created a custom middleware
- Added Authentication to your web applications

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.
