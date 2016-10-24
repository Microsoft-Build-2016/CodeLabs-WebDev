<a name="HOLTop" ></a>
# Front End Development #

---

<a name="Overview" ></a>
## Overview ##

In traditional web applications, the client (browser) initiates the communication with the server by requesting a page. The server then processes the request and sends the HTML of the page to the client. In subsequent interactions with the page (e.g. the user navigates to a link or submits a form with data) a new request is sent to the server, and the flow starts again: the server processes the request and sends a new page to the browser in response to the new action requested by the client.

In Single-Page Applications (SPAs) the entire page is loaded in the browser after the initial request, but subsequent interactions take place through Ajax requests. This means that the browser has to update only the portion of the page that has changed; there is no need to reload the entire page. The SPA approach reduces the time taken by the application to respond to user actions, resulting in a more fluid experience.

The architecture of a SPA involves certain challenges that are not present in traditional web applications. However, modern JavaScript frameworks like AngularJS, combined with HTTP services provided by ASP.NET Core, make it really easy to design and build SPAs.

In this module, you will take advantage of those technologies to implement a website based on the SPA concept. You'll first work with a rich and responsive UI using **Angular 2** taking advantage of the Visual Studio Tooling. Then, you'll implement the service layer with **ASP.NET Core API** to expose the required endpoints. You'll then check your application for web standards compliance using the **Vorlon.js** Edge extension, and see how you can package it as an app using **ManifoldJS**.

<a name="Objectives" ></a>
### Objectives ###
In this module, you will see how to:

- Work with Single Page Applications using Angular 2
- Leverage Visual Studio web tools
- Integrate HTTP services using ASP.NET Core web api's
- Test your applications for web standards compliance with the Vorlon.js Edge extension
- Package your site as an app using ManifoldJS

<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this module:

- [Visual Studio Community 2015][1] or greater.
- [ASP.NET Core 1.0][2]
- [Web Extension Pack][3]
- [npm][4]
- [TypeScript][5]
- [ManifoldJS][6]

[1]: https://www.visualstudio.com/products/visual-studio-community-vs
[2]: https://get.asp.net
[3]: https://visualstudiogallery.msdn.microsoft.com/f3b504c6-0095-42f1-a989-51d5fc2a8459
[4]: https://www.npmjs.com/
[5]: http://www.typescriptlang.org/
[6]: http://manifoldjs.com/

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.

<a name="Setup" ></a>
### Setup ###
In order to run the exercises in this module, you will need to set up your environment first.

1. Open Windows Explorer and browse to the module's **Source** folder.
1. Right-click **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this module.
1. If the User Account Control dialog box is shown, confirm the action to proceed.

> **Note:** Make sure you have checked all the dependencies for this module before running the setup.

Ensure Developer Mode is enabled on Windows 10 by going to settings > Update & Security > For developers and selecting **Developer mode**. 

<a name="CodeSnippets" ></a>
### Using the Code Snippets ###

Throughout the module document, you will be instructed to insert code blocks. For your convenience, most of this code is provided as Visual Studio Code Snippets, which you can access from within Visual Studio 2015 to avoid having to add it manually.

>**Note**: Each exercise is accompanied by a starting solution located in the **Begin** folder of the exercise that allows you to follow each exercise independently of the others. Please be aware that the code snippets that are added during an exercise are missing from these starting solutions and may not work until you have completed the exercise. Inside the source code for an exercise, you will also find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the corresponding exercise. You can use these solutions as guidance if you need additional help as you work through this module.

---

<a name="Exercises" ></a>
## Exercises ##
This module includes the following exercises:

1. [Creating an Angular 2 application](#Exercise1)
1. [Exploring a more advanced Angular 2 application in an ASP.NET Core application](#Exercise2)
1. [Integrating with ASP.NET Core API controller](#Exercise3)
1. [Developing for Web Standards with Edge and Vorlon.js](#Exercise4)
1. [Packaging SPA as an installable App using ManifoldJS](#Exercise5)

Estimated time to complete this module: **60 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this module describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1" ></a>
### Exercise 1: Creating an Angular 2 application ###

**Angular** is a development platform for building mobile and desktop web applications using modern web standards. Is an open-source JavaScript framework that augments browser-based applications with Model-View-Controller (MVC) capability, facilitating both development and testing.

In this exercise, you will learn the basics of **Angular 2** taking advantage of the official documentation.

<a name="Ex1Task1" ></a>
#### Task 1 - Introducing the Angular 2 documentation ####

In this task, you will explore some of the resources that Angular 2 have to start working with it.

1. Open **Microsoft Edge** and navigate to the [Angular 2](https://angular.io/) site. The home page includes some basic examples as well as some of the features included as part of Angular 2.

1. Navigate to the [Angular 2 Doc's page](https://angular.io/docs/ts/latest/) by clicking the **DOCS** button located at the top menu. In that page you can find several resources.

1. Navigate to the [Angular Cheat Sheet](https://angular.io/docs/ts/latest/cheatsheet.html) located under the **REFERENCE** section in the left menu. In this page you can find a summary of the most useful template syntaxes, build-in directives, forms directives, class decorators and more.

1. If you have experience working with Angular 1, you can find useful the [Angular 1 to 2 Quick ref](https://angular.io/docs/ts/latest/cookbook/a1-a2-quick-reference.html) page, located under the **COOKBOOK** section in the left menu.

1. The documentation site includes a lot of more advanced content for you to look at later, including [full docs](https://angular.io/docs/ts/latest/guide/), an [full tutorial](https://angular.io/docs/ts/latest/tutorial/) and more.

<a name="Ex1Task2" ></a>
#### Task 2 - Exploring the Angular 2 Quickstart ####

In this task, you will explore the code in the [5 Minutes Quickstart](https://angular.io/docs/ts/latest/quickstart.html) page.

1. In **Microsoft Edge**, navigate to the [5 Minutes Quickstart](https://angular.io/docs/ts/latest/quickstart.html) page and click the [live example](https://angular.io/resources/live-examples/quickstart/ts/plnkr.html) link in the **See It Run** section.

	> **Note:** If you have any issues opening the live example link, you can find the files in the **Source/Ex1/Begin** folder.

	![Openning the live sample](Images/openning-the-live-example.png?raw=true "Openning the live sample")

	_Openning the live sample_

1. In the quickstart's live preview, open the **index.html** file and locate the dependencies required by Angular 2 under the `<!-- 1. Load libraries -->` comment.

	````HTML
    <!-- 1. Load libraries -->
    <!-- IE required polyfills, in this exact order -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/es6-shim/0.33.3/es6-shim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/systemjs/0.19.20/system-polyfills.js"></script>
    <script src="https://unpkg.com/angular2@2.0.0-beta.8/es6/dev/src/testing/shims_for_IE.js"></script>   

    <script src="https://code.angularjs.org/2.0.0-beta.8/angular2-polyfills.js"></script>
    <script src="https://code.angularjs.org/tools/system.js"></script>
    <script src="https://unpkg.com/typescript@1.8.2/lib/typescript.js"></script>
    <script src="https://code.angularjs.org/2.0.0-beta.8/Rx.js"></script>
    <script src="https://code.angularjs.org/2.0.0-beta.8/angular2.dev.js"></script>
	````

	> **Note:** The following is a brief description of each library.
	>
	> - **ES6 Shim**: This library provides compatibility shims so that legacy JavaScript engines behave as closely as possible to ECMAScript 6
	> - **SystemJS**: An universal dynamic module loader - loads ES6 modules, AMD, CommonJS and global scripts in the browser and NodeJS. Works with both Traceur and Babel.
	> - **TypeScript**: is a typed superset of JavaScript that compiles to plain JavaScript.
	> - **RxJS**: The Reactive Extensions for JavaScript (RxJS) is a set of libraries to compose asynchronous and event-based programs using observable collections and Array#extras style composition in JavaScript.
	> - **Angular 2**: The core Angular 2 library which provides all the components to create your apps.
	> - **SystemJS** and **Angular 2** polyfills: A polyfill (or polyfiller) is additional code which provides facilities that are not built into a web browser. It implements technology that each of the libraries depend on.

1. Note that there are no references to the applications files. The main.ts and the app.component.ts files are loaded by **SystemJS**, in order to do that, System.js is configured by the following code to transpile the **TypeScript** files and import the **main** file.

	````HTML
    <!-- 2. Configure SystemJS -->
    <script>
      System.config({
        transpiler: 'typescript',
        typescriptOptions: { emitDecoratorMetadata: true },
        packages: {'app': {defaultExtension: 'ts'}}
      });
      System.import('app/main')
            .then(null, console.error.bind(console));
    </script>
	````

1. In order to add the Angular application to your **index.html** file you only need to add the **my-app** tag inside the body. The tag name is the one defined as the **selector** in your **Component**.

	````HTML
	<!-- 3. Display the application -->
	<body>
		<my-app>Loading...</my-app>
	</body>
	````

1. Now, open to the **main.ts** file located at the **app** folder by clicking in the **app/main.ts** link under _FILES_ in the left menu.

	![Openning the main.ts file](Images/openning-the-main-ts.png?raw=true "Openning the main.ts file")

	_Openning the main.ts file_

1. The **app/main.ts** file is the first one loaded by _System.JS_ as it was the one specified in the _import_ method call. Note that this file contains two imports which loads the components from the files specified after the **from** statement.

	````TypeScript
	import {bootstrap}    from 'angular2/platform/browser'
	import {AppComponent} from './app.component'

	bootstrap(AppComponent);
	````

1. Open the **app.component.ts** file located at the **app** folder. Every Angular app has at least one root component, conventionally named AppComponent, that hosts the client user experience. Components are the basic building blocks of Angular applications. A component controls a portion of the screen — a view — through its associated template.

	````TypeScript
	import {Component} from 'angular2/core';

	@Component({
		selector: 'my-app',
		template: '<h1>My First Angular 2 App</h1>'
	})
	export class AppComponent { }
	````

1. Note the **Component** decorator of the _AppComponent_ class. This decorator takes a metadata object including the selector and the template. The _selector_ specifies a simple CSS selector for and HTML element that represents the component, in this case the _my-app_ tag. The _template_ specifies the component's companion template, written in an enhanced form of HTML that tells Angular how to render this component's view.

	````TypeScript
	@Component({
		selector: 'my-app',
		template: '<h1>My First Angular 2 App</h1>'
	})
	````

1. Update the **AppComponent** class implementation by adding a new private property named _name_ with your name as value (e.g. _John Doe_)

	````TypeScript
	export class AppComponent {
	  private name = "John Doe";
	}
	````

1. Now update the **template** property in the **@Component** decoration with data bindings to this new property.

	````TypeScript
	@Component({
		selector: 'my-app',
		template: '<h1>Hello {{name}}!</h1>'
	})
	````

	![Updating the quickstart sample](Images/updating-the-quickstart-sample.png?raw=true "Updating the quickstart sample")

	_Updating the quickstart sample_


<a name="Exercise2" ></a>
### Exercise 2: Exploring a more advanced Angular 2 application in an ASP.NET Core application ###

In a real world application, you will generally have more than a single component and they will be more complex, not only showing the data using bindings but enabling editing it and changing the behavior based on the state. Additionally, you might use complex component like grids that supports different kind of events as well as editing the values that are displayed.

In this exercise, you'll explore a more advanced application that uses Angular 2 in the front end and ASP.NET Core in the back end. You'll also explore the Visual Studio tooling that make your life easier when developing this kind of applications.

> **Note:** OrderApp is showing mock data at this point. In the next exercise, you'll wire it up to the back-end. Additionally, as this module will only cover part of the solution, we encourage you to explore and play with the application after completing the module.

<a name="Ex2Task1"></a>
#### Task 1 - Exploring the application ####

In this task, you will explore the **OrderApp** application which uses two grids to show all the orders from a store and its details whenever you select one of the orders in the main grid.

1. Open **Visual Studio Community 2015** and the **OrderApp.sln** solution located in the **Source/Ex2/Begin** folder. Compile the solution and wait until all the dependencies are loaded.

1. Expand the **js** folder inside **wwwroot** and notice that you this solution uses **TypeScript**. Visual Studio have great support for working with TypeScript. By compiling the application, you will obtain the transpiled version of the typescript files, enabling you to consume JavaScript files directly instead of TypeScript files.

	![TypeScript files in wwwroot](Images/typescript-files-in-wwwroot.png?raw=true "TypeScript files in wwwroot")

	_TypeScript files in wwwroot_

1. Open the **tsconfig.json** file located at the root of the **OrderApp** project and notice that this file configures **TypeScript**, enabling the use of _decorators_ and setting _system_ for _modules_.

	````JSON
	{
	  "compilerOptions": {
		 "noImplicitAny": false,
		 "noEmitOnError": true,
		 "removeComments": false,
		 "sourceMap": true,
		 "target": "es5",
		 "emitDecoratorMetadata": true,
		 "experimentalDecorators": true,
		 "module": "system",
		 "moduleResolution": "node"
	  },
	  "exclude": [
		 "node_modules",
		 "wwwroot/lib"
	  ]
	}
	````

1. Right-click the **npm** folder under **Dependencies** and select **Open package.json** in order to open the npm _package.json_ file.

	![Openning the package.json file](Images/openning-package-json.png?raw=true "Openning the package.json file")

	_Openning the package.json file_

1. Locate the **dependencies** node inside the _package.json_ file. In that node, you can find the Angular 2 dependencies described in the previous exercise. Additionally, note that there are two additional dependencies _ag-grid_ and _ag-grid-ng2_ which enable you to use a grid component in your application.

	````JSON
	{
	  "name": "ASP.NET",
	  "version": "0.0.0",
	  "dependencies": {
		 "ag-grid": "4.0.x",
		 "ag-grid-ng2": "4.0.x",
		 "angular2": "2.0.0-beta.8",
		 "systemjs": "0.19.24",
		 "es6-shim": "^0.35.0",
		 "rxjs": "5.0.0-beta.2"
	  },
	  "devDependencies": {
		 "gulp": "3.8.11",
		 "gulp-concat": "2.5.2",
		 "gulp-cssmin": "0.1.7",
		 "gulp-uglify": "1.2.0",
		 "rimraf": "2.2.8"
	  }
	}
	````

1. These dependencies will be located at the **node_modules** folder which is not served by the web server. In order to be able to consume them, you will need to move the inside the **wwwroot** folder. Open the **gulpfile.js** file located at the root of the **OrderApp** project.

1. In the **gulpfile.js** file you can find some tasks that will copy each of the dependencies to the **lib/npmlibs/** folder inside **wwwroot**. The main task is **moveToLibs** which depends on the **moveToLibs:singleFiles** as well as all the _copy-deps_ tasks.

	````JavaScript
	// ...

	gulp.task(**"copy-deps:ag-grid"**, function () {
		 return gulp.src([paths.npmSrc + '/ag-grid/main.js',
						 paths.npmSrc + '/ag-grid/dist/**/*.js',
						 paths.npmSrc + '/ag-grid/dist/styles/*.*'
		 ], { base: paths.npmSrc + '/ag-grid/' })
				.pipe(gulp.dest(paths.npmLibs + '/ag-grid/'));
	});

	gulp.task(**'moveToLibs:singleFiles'**, function () {
		 return gulp.src(libsToMove).pipe(gulp.dest(paths.npmLibs));
	});

	gulp.task(**"moveToLibs"**, ["moveToLibs:singleFiles", "copy-deps:ag-grid-ng2", "copy-deps:ag-grid", 'copy-deps:angular2', 'copy-deps:systemjs']);
	````

1. In the **Task Runner Explorer** view, right-click the **moveToLibs** task and select **Run** to execute the task. Note that in the same menu, you can bind the tasks to before or after the build, the clean of the project or when the project opens.

	![Running the moveToLibs task](Images/running-the-movetolibs-task.png?raw=true "Running the moveToLibs task")

	_Running the moveToLibs task_

1. Open the **_Layout.cshtml** file located under the **Views/Shared** folder. Locate all the dependencies at the end of the _head_ tag. Note that this files are loaded from the **~/lib/npmlibs/** folder which is where the gulp tasks is moving the dependencies.

	![Dependencies loaded from the npmlibs folder](Images/deps-loaded-from-npmlibs-folder.png?raw=true "Dependencies loaded from the npmlibs folder")

	_Dependencies loaded from the npmlibs folder_

1. Open the **Index.cshtml** file located under the **Views/Home** folder. Note that there is an **order-app** tag which is the main component's selector. Additionally, you can find the _System.js_ configuration as well as the import of the _boot_ file.

	![Index.cshtml file with System.js configuration](Images/index-file-with-systemjs-config.png?raw=true "Index.cshtml file with System.js configuration")

	_Index.cshtml file with System.js configuration_

1. Now, open the **boot.ts** file located at the **js** folder inside **wwwroot**. This file bootstraps the **OrderApp** component located in the **order-app.component.ts** file.

1. Open the **order-app.component.ts** file. In the top of the file, you will find several imports including two that corresponds to **AgGrid** and additionally, one for the **OrderService** service and another one for the **DetailsGridComponent**.

	````TypeScript
	import {Component, View, OnInit} from "angular2/core";
	import {GridOptions} from "ag-grid/main";
	import {AgGridNg2} from "ag-grid-ng2/main";
	import RefData from "./refData";
	import {IItemInfo} from "./itemInfo";
	import {DetailsGridComponent} from "./details-grid.component";
	import {OrderService} from "./order.service";
	````

1. Note that the **OrderApp** component defines its template in a separated html file named **order-app.html** which is located in the **html** folder. Open this file to see how the ag-grid and details-grid components are used inside this component.

	````HTML
    <ag-grid-ng2 #agGrid id="master-grid" class="ag-blue"
                    [gridOptions]="gridOptions"
                    [columnDefs]="columnDefs"
                    [rowData]="rowData"
                    enableColResize
                    enableSorting
                    enableFilter
                    groupHeaders
                    rowHeight="22"
                    rowSelection="single"
                    suppressCellSelection
                    (modelUpdated)="onModelUpdated()"
                    (rowClicked)="onRowClicked($event)"
                    (ready)="onReady($event)">
    </ag-grid-ng2>

    <details-grid [itemInfo]="selectedItem" (updatedTotal)="updateOrderTotal($event)"></details-grid>
	````

1. Back in the **order-app.component.ts** file, locate the **Component** decorator and notice the **providers** property. This property is used to configure the dependency injection system in this case configuring the **OrderService** that its consumed in the class's constructor.

	````TypeScript
    constructor(private _orderService: OrderService) {
        // we pass an empty gridOptions in, so we can grab the api out
        this.gridOptions = <GridOptions>{};
        this.createColumnDefs();
    }
	````

1. In order to be able to inject a class you need that it has the **Injectable** decorator. Open the **order.service.ts** file and verify that this service has this decorator. Note that this service is using mock data, in the next exercise you will update it to consume an API to retrieve and save the data in the server.

<a name="Ex2Task2"></a>
#### Task 2 - Running the Solution ####

In this task, you will execute the solution.

1. Press **F5** to run the solution.

	![Running the OrderApp solution](Images/running-the-orderapp-sln.png?raw=true "Running the OrderApp solution")

	_Running the OrderApp solution_

1. Select one of the rows to see the details of that specific order.

	![Selecting an order](Images/selecting-an-order.png?raw=true "Selecting an order")

	_Selecting an order_

1. Modify the quantities of one of the items in the order and verify that the totals fields are updated. You can also update the comments field.

	![Editing an Order item](Images/editing-an-order-item.png?raw=true "Editing an Order item")

	_Editing an Order item_

1. Go back to Visual Studio and press **SHIFT + F5** to stop debugging.

<a name="Exercise3" ></a>
### Exercise 3: Integrating with ASP.NET Core API controller ###

One of the key parts of a SPA is the service layer. It is responsible for processing the Ajax calls sent by the UI and returning data in response to that call. The data retrieved should be presented in a machine-readable format in order to be parsed and consumed by the client. ASP.NET Core is designed to make it easy to implement HTTP services, generally sending and receiving JSON- or XML-formatted data through a RESTful API.

In this exercise, you'll create an **ASP.NET Core API** and then update the **OrderService** in the Angular application to call the new API to retrieve and store the information.

<a name="Ex3Task1" ></a>
#### Task 1 - Creating an ASP.NET Core API controller ####

In this task, you'll build a simple API service that interacts with the OrderApp's model and exposes the following actions:

- **GET /api/orders**: Retrieves all the available orders.
- **GET /api/orders/{id}**: Retrieves all the order's details including all items that are part of that order.
- **PUT /api/orderDetails/{id}**: Stores the changes in the existing order details' items like quantities and comments.

You'll use ASP.NET Core API, creating an API Controller class to each of the endpoints (i.e. _orders_ and _orderDetails_).

1. Open **Visual Studio Community 2015** and the **OrderApp.sln** solution located in the **Source/Ex2/Begin** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. In **Solution Explorer**, right-click the **ViewModels** folder of the **OrderApp** project and select **Add | Class...**. Name the class file  **OrderViewModel.cs** and click **Add**.

1. Replace the OrderViewModel class with the following code snippet.

	(Code Snippet - _FrontEndDev - Ex3 - OrderViewModelClass_)
	<!--mark: 1-20-->
	````C#
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public decimal OrderTotal { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Continent { get; set; }

        public string Language { get; set; }

        public string Phone { get; set; }
    }
	````

1. Add a new view model class. To do this, in **Solution Explorer**, right-click the **ViewModels** folder of the **OrderApp** project and select **Add | Class...**. This time, name the class file **OrderDetailsItem.cs** and click **Add**.

1. Replace the OrderDetailsItem class with the following code snippet.

	(Code Snippet - _FrontEndDev - Ex3 - OrderDetailsItemClass_)
	<!--mark: 1-16-->
	````C#
    public class OrderDetailsItem
    {
        public int OrderDetailsId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Comments { get; set; }

        public decimal Total { get { return this.Price * this.Quantity;  } }
    }
	````

1. In **Solution Explorer**, right-click the **Controllers** folder of the **OrderApp** project and select **Add | New Item...**.

1. In the **Add New Item** dialog box, make sure that the **DNX | Server-side** node is selected in the left pane. Then, select the **Web API Controller Class** template in the center pane, name it _OrdersController_ and click **Add**.

	![Selecting the Web API Controller Class template](Images/selecting-web-api-controller-class.png?raw=true "Selecting the Web API Controller Class template")

	_Selecting the Web API Controller Class template_

1. The **OrdersController.cs** file is then added to the **Controllers** folder of the **OrderApp** project, containing a base **OrdersController** class. Remove all the content of the class and add the following using statements at the beginning of the file.

	(Code Snippet - _FrontEndDev - Ex3 - OrdersControllerUsings_)
	<!--mark: 1-3-->
	````C#
	using Microsoft.Data.Entity;
	using OrderApp.Models;
	using OrderApp.ViewModels;
	````

1. Add the following code at the **OrdersController** class to define, initialize and dispose the **OrdersContext** instance in the controller.

	(Code Snippet - _FrontEndDev - Ex3 - OrdersControllerContext_)
	<!-- mark:6-21 -->
	````C#
	namespace OrderApp.Controllers
	{
		 [Route("api/[controller]")]
		 public class OrdersController : Controller
		 {
			  private OrdersContext context;

			  public OrdersController(OrdersContext context)
			  {
					this.context = context;
			  }

			  protected override void Dispose(bool disposing)
			  {
					if (disposing)
					{
						 this.context.Dispose();
					}

					base.Dispose(disposing);
			  }
		 }
	}
	````

	> **Note 1:** The **Dispose** method of **OrdersController** invokes the **Dispose** method of the **OrdersContext** instance, which ensures that all the resources used by the context object are released when the **OrdersContext** instance is disposed or garbage-collected. This includes closing all database connections opened by Entity Framework.

	> **Note 2:** The OrdersContext will be automatically injected by ASP.NET Core thanks to the configuration in the **Startup** class.

1. Add the following **Get** action method to the **OrdersController** class. This action method retrieves all the orders from the context and creates a new **OrderViewModel** instance for each one.

	(Code Snippet - _FrontEndDev - Ex3 - OrdersControllerGetAction_)
	<!-- mark:1-18 -->
	````C#
    // GET: api/orders
    [HttpGet]
    public IEnumerable<OrderViewModel> Get()
    {
        return this.context.Orders.Select(o =>
            new OrderViewModel()
            {
                Address = o.Address,
                OrderTotal = o.OrderDetails.Select(od => od.Quantity * od.Product.Price).Sum(),
                Continent = o.Continent,
                Country = o.Country,
                Language = o.Language,
                Date = o.Date.ToString(),
                Name = o.Name,
                Id = o.OrderId,
                Phone = o.Phone
            });
    }
	````

1. Add the following **GetOrder** action method to the **OrdersController** class. This action method retrieves the order details from the context and create a new **OrderDetailsItem** instance for each one of the **OrderDetail** instances that match the order's id.

	(Code Snippet - _FrontEndDev - Ex3 - OrdersControllerGetOrderAction_)
	<!-- mark:1-29 -->
	````C#
    // GET: api/orders/5
    [HttpGet("{id}", Name = "GetOrder")]
    public async Task<IActionResult> GetOrder([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return HttpBadRequest(ModelState);
        }

        var order = await this.context.Orders
                                            .Include(o => o.OrderDetails)
                                            .ThenInclude(od => od.Product)
                                            .SingleAsync(m => m.OrderId == id);

        if (order == null)
        {
            return HttpNotFound();
        }

        return Ok(order.OrderDetails.Select(orderDetails => new OrderDetailsItem()
        {
            Comments = orderDetails.Comments,
            OrderDetailsId = orderDetails.OrderDetailsId,
            ProductName = orderDetails.Product.Name,
            ProductId = orderDetails.Product.ProductId,
            Price = orderDetails.Product.Price,
            Quantity = orderDetails.Quantity
        }));
    }
	````

1. Modify the API controller to produce json by adding the **Produces** attribute to the **OrdersController** class definition.

	<!-- mark:3 -->
	````C#
	namespace OrderApp.Controllers
	{
		 [Produces("application/json")]
		 [Route("api/[controller]")]
		 public class OrdersController : Controller
		 {
			  // ...
		 }
	}
	````

1. Create a new controller named _OrderDetailsController_. To do this, in **Solution Explorer**, right-click the **Controllers** folder of the **OrderApp** project and select **Add | New Item...**. In the **Add New Item** dialog box, make sure that the **DNX | Server-side** node is selected in the left pane. Then, select the **Web API Controller Class** template in the center pane, name it _OrderDetailsController_ and click **Add**.

1. In the **OrderDetailsController.cs** file, replace all the content of the file with the following code snippet to add the using statements and initialize and dispose the **OrdersContext** instance in the controller in the same way that was performed in the other controller.

	(Code Snippet - _FrontEndDev - Ex3 - OrderDetailsControllerBase_)
	<!--mark: 1-31-->
	````C#
	using System.Threading.Tasks;
	using Microsoft.AspNet.Http;
	using Microsoft.AspNet.Mvc;
	using Microsoft.Data.Entity;
	using OrderApp.Models;
	using OrderApp.ViewModels;

	namespace OrderApp.Controllers
	{
		 [Produces("application/json")]
		 [Route("api/[controller]")]
		 public class OrderDetailsController : Controller
		 {
			  private OrdersContext context;

			  public OrderDetailsController(OrdersContext context)
			  {
					this.context = context;
			  }

			  protected override void Dispose(bool disposing)
			  {
					if (disposing)
					{
						 this.context.Dispose();
					}

					base.Dispose(disposing);
			  }
		 }
	}
	````

1. Add the following **PutOrderDetails** action method to the **OrderDetailsController** class. This action method saves the changes in the details's item.

	(Code Snippet - _FrontEndDev - Ex3 - OrderDetailsControllerPutOrderDetailsAction_)
	<!-- mark:1-28 -->
	````C#
    // PUT: api/OrderDetails/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrderDetails([FromRoute] int id, [FromBody] OrderDetailsItem orderDetails)
    {
        if (!ModelState.IsValid)
        {
            return HttpBadRequest(ModelState);
        }

        if (id != orderDetails.OrderDetailsId)
        {
            return HttpBadRequest();
        }

        var storedOrderDetails = await this.context.OrderDetails.SingleAsync(m => m.OrderDetailsId == id);

        if (storedOrderDetails == null)
        {
            return HttpNotFound();
        }

        storedOrderDetails.Quantity = orderDetails.Quantity;
        storedOrderDetails.Comments = orderDetails.Comments;

        await this.context.SaveChangesAsync();

        return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
    }
	````

<a name="Ex3Task2" ></a>
#### Task 2 - Integrating the front end with the API controller ####

In this task, you will use Angular's **Http** service to perform http requests to the API created in the previous task using **XMLHttpRequest**.

1. Open the **boot.ts** file located in the **js** folder under **wwwroot**.

1. Add a new import statement for **HTTP_PROVIDERS** from **angular2/http** and add it to the bootstrap function call in the second parameter wrapped as an array.

	````TypeScript
	"use strict";

	import {bootstrap}  from "angular2/platform/browser";
	import {OrderApp} from "./order-app.component";
	import {HTTP_PROVIDERS} from "angular2/http";

	bootstrap(OrderApp, [HTTP_PROVIDERS]);
	````

1. Open the **order.service.ts** file located in the **js** folder under **wwwroot**.

1. In the top of the **order.service.ts** file, remove the MockOrders imports and add the following two imports to use the **Http** service.

	````TypeScript
	import {Http, Headers, RequestOptions, Response} from "angular2/http";
	import "rxjs/Rx";
	````

1. Add two new private properties to the _OrderService_ class, one for each of the endpoints.

	````TypeScript
    private orderEndpoint = "/api/orders/";
    private orderDetailsEndpoint = "/api/orderDetails/";
	````

1. Add the constructor of the _OrderService_ class below the new properties to be able to inject the **Http** service and consume it from the methods.

	````TypeScript
    private orderEndpoint = "/api/orders/";
    private orderDetailsEndpoint = "/api/orderDetails/";

    constructor(private http: Http) {
    }
	````

1. Replace the implementation of the **getOrders** method with the following code that uses the get method of the **Http** service.

	````TypeScript
    getOrders(): Promise<IItemInfo[]> {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Mon, 27 Mar 1972 00:00:00 GMT");

        return this.http.get(this.orderEndpoint, { headers: headers })
            .map((res: Response) => <IItemInfo[]>res.json())
            .toPromise();
    }
	````

1. Replace the implementation of the **getOrderDetails** method with the following one.

	````TypeScript
    getOrderDetails(id: number): Promise<any> {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Mon, 27 Mar 1972 00:00:00 GMT");
        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.orderEndpoint + id, options)
            .map((res: Response) => res.json())
            .toPromise();
    }
	````

1. Replace the implementation of the **updateOrderDetails** method with the following code that take advantage of the put method of the **Http** service to send the updated orderDetails.

	````TypeScript
    updateOrderDetails(orderDetails: any): Promise<any> {
        let body = JSON.stringify(orderDetails);
        let headers = new Headers({ "Content-Type": "application/json" });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this.orderDetailsEndpoint + orderDetails.orderDetailsId, body, options)
            .toPromise();
    }
	````

<a name="Ex3Task3"></a>
#### Task 3 - Running the Solution ####

In this task, you will execute the solution to verify that the data is loaded and stored in the backend.

1. In **Visual Studio**, press **F5** to run the solution.

1. Once the site is running in **Microsoft Edge**, open the **F12 Developers Tools** by pressing **F12** and switch to the **Network** tab. Make sure that its recording and clear the session.

	![Networks tab of the F12 Developers Tools](Images/network-tab-f12-tools.png?raw=true "Networks tab of the F12 Developers Tools")

	_Networks tab of the F12 Developers Tools_

1. Select one of the rows to see the details of that specific order.

	![Selecting an order](Images/selecting-an-order.png?raw=true "Selecting an order")

	_Selecting an order_

1. Switch back to the **F12 Developers Tools** to see the new request. Select the request from the list and then select the **Body** tab from the details to see the JSON response.

	![Body details of the GET request](Images/body-details-from-get-request.png?raw=true "Body details of the GET request")

	_Body details of the GET request_

1. Modify the quantities of one of the items in the order and verify that the totals fields are updated. You can also update the comments field.

	![Editing an Order item](Images/editing-an-order-item.png?raw=true "Editing an Order item")

	_Editing an Order item_

1. Switch back to the **F12 Developers Tools** to see the new request. Select the new request from the list and then select the **Request Body** tab instead of **Response body**.

	![Body details of the PUT request](Images/body-details-from-put-request.png?raw=true "Body details of the PUT request")

	_Body details of the PUT request_

1. Close the **F12 Developers Tools** and refresh the browser by pressing **F5** to verify that the fields were updated in the database.

1. Go back to Visual Studio and press **SHIFT + F5** to stop debugging.

<a name="Exercise4" ></a>
### Exercise 4: Developing for Web Standards with Edge and Vorlon.js ###

**Vorlon.JS** is a remote debugging and testing tool for JavaScript. It helps you remotely load inspect, test and debug JavaScript code running on any device with a web browser: whether it's a games console, mobile device or fridge.

In this exercise you will take advantage of using **Vorlon.JS** to improve your site.

<a name="Ex4Task1" ></a>
#### Task 1 - Using Vorlon.js Extension ####

In this task you will use the **Vorlon.js Extension** to analyze your site in order to detect issues.

1. Open **Visual Studio Community 2015** and the **OrderApp.sln** solution located in the **Source/Ex3/End** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. Run the solution in **Microsoft Edge** by pressing **F5** in **Visual Studio**.

1. In **Microsoft Edge**, start the **Vorlon.js** extension.

1. Once the Vorlon.js page appears, select the **Home Page - OrderApp** site under the **TAB LIST** located at the left panel and run the analysis by clicking the **Start checks** button on the top bar.

	![Starting the checks for OrderApp](Images/starting-checks.png?raw=true "Starting the checks for OrderApp")

	_Starting the checks for OrderApp_

1. Once the analysis is completed, explore the results by clicking the rules to get more context about each of them.


	![Page analyzer results](Images/page-analyzer-results.png?raw=true "Page analyzer results")

	_Page analyzer results_

1. The analysis is designed to provide guidance regarding web standards, accessibility, performance and the mobile web. Expand all of the categories and explore the results.

	![Exploring all the categories](Images/exploring-all-the-categories.png?raw=true "Exploring all the categories")

	_Exploring all the categories_

<a name="Ex4Task2" ></a>
#### Task 2 - Using Vorlon.js server ####

**Vorlon.JS** itself is a small web server you can run from your local machine, or install on a server for your team to access, that serves the Vorlon.JS dashboard and communicates with your remote devices. Installing the Vorlon.JS client in your web site or application is as easy as adding a single script tag.

In this task, you will set up **Vorlon.JS** and integrate it in your web application.

1. Open a **Command Prompt** and validate that you have npm installed by executing `npm -v`.

1. Install vorlon.js by executing the following command in the **Command Prompt**.

	````
	npm install -g vorlonjs
	````

1. In a **Command Prompt**, run the `vorlon` command to initialize the vorlon.js server. Don't close it until the end of this exercise.

1. In **Visual Studio**, open the _Layout.cshtml_ file located at the **Views/Shared** folder and add the following script tag under the **title** tag inside the **head** tag.

	````HTML
	<script src="http://localhost:1337/vorlon.js"></script>
	````

1. Run the web application using **Ctrl + F5** and don't stop it as you will need the app running for the following steps.

1. Open another instance of **Microsoft Edge** and navigate to [http://localhost:1337/](http://localhost:1337/) in order to see the **Vorlon.JS dashboard**.

1. Select the **Windows - 0** option under **CLIENT LIST** the left panel and explore the different features by selecting the tabs in the top menu of the **Vorlon.JS dashboard**.

	![Using Vorlon.js Dashboard](Images/using-vorlonjs-dashboard.png?raw=true "Using Vorlon.js Dashboard")

	_Using Vorlon.js Dashboard_

<a name="Exercise5" ></a>
### Exercise 5: Packaging SPA as an installable App using ManifoldJS ###

Hosted Apps are web apps submitted to app markets that point to web content that remains on the web server as appose to being packaged and submitted to the store.

ManifoldJS helps you reach more users by packaging your web experience as native apps across _Android_, _iOS_, _Windows_, _Firefox OS_, and _Chrome_. Its takes the meta-data about your site taking advantage of the _W3C Manifest for web apps and bookmarks_ standard and generates native "hosted" apps.

In this exercise, you will use _ManifoldJS_ to create a Hosted Web Application for your Web application.

<a name="Ex5Task1" ></a>
#### Task 1 - Creating a Hosted Web Application with ManifoldJS ####

In essence, a Hosted Web App is a container app. The content of the app (or the majority of the content) is hosted on a web server. To the customer, a Hosted Web App looks and feels like any other Store app. For the developer, the app is a standalone instance of the web app with all the features and privileges of a Store app. The same code that runs in the Hosted Web App can also run in a browser, as well as be reused on other platforms.

In this task, you will create a _Hosted Web Application_ using _ManifoldJS_ and the _W3C Manifest_.

1. Open **Visual Studio Community 2015** and the **OrderApp.sln** solution located in the **Source/Ex4/End** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. In **Solution Explorer**, right-click the **wwwroot** folder and select **Add | New Item...**. Select **JSON File** under the **DNX | Client-Side** menu, change the name to _manifest.json_ and click **Add**.

	![Creating the manifest.json file](Images/creating-the-manifest.png?raw=true "Creating the manifest.json file")

	_Creating the manifest.json file_

1. In the _manifest.json_ add the following code snippet to declare the sites information using the _W3C Manifest for Web Apps_ standard.

	````JSON
	{
	  "name": "OrderApp",
	  "short_name": "OrderApp",
	  "start_url": "http://localhost:55804/",
	  "icons": [
		 {
			"src": "images/splashscreen.png",
			"sizes": "620x300"
		 },
		 {
			"src": "images/logo.png",
			"sizes": "150x150"
		 },
		 {
			"src": "images/widelogo.png",
			"sizes": "310x150"
		 },
		 {
			"src": "images/storelogo.png",
			"sizes": "50x50"
		 },
		 {
			"src": "images/logo44.png",
			"sizes": "44x44"
		 },
		 {
			"src": "images/smalllogo.png",
			"sizes": "30x30"
		 }
	  ],
	  "splash_screens": [
		 {
			"src": "images/splashscreen.png",
			"sizes": "620x300"
		 }
	  ],
	  "mjs_api_access": [
		 {
			"match": "http://localhost:55804/*",
			"access": "all",
			"platform": "windows10"
		 }
	  ],
	  "theme_color": "#7D89A2"
	}
	````

1. Copy the images from the **Source/Ex5/Assets** folder to the **wwwroot/images** folder.

	![Assets' images in wwwroot](Images/assets-images-in-wwwroot.png?raw=true "Assets' images in wwwroot")

	_Assets' images in wwwroot_

1. Open the _Layout.cshtml_ file located at the **Views/Shared** folder and add the following line under the **title** tag inside the **head** tag. You can take this oportunity to remove the tag you added in the previous exercise for the vorlon.js client.

	````HTML
	<link rel="manifest" href="manifest.json">
	````

1. Run the web application using **Ctrl + F5** and don't stop it as you will need the app running for the following steps.

1. Open a **Command Prompt** and validate that you have npm installed by executing `npm -v`.

1. Install [ManifoldJS](http://www.manifoldjs.com/) by executing the following command in the **Command Prompt**.

	````
	npm install -g manifoldjs
	````

1. Once _ManifoldJS_ is installed, run the following command in the same **Command Prompt** to see all the possible parameters for **manifoldjs**.

	````
	manifoldjs -h
	````

1. Run the following command to create the Windows 10 app based on the _W3C Manifest_ previously created. Note that we are specifying the platform to be Windows 10. Additionally, note that the port number should match the ones specified in the _manifest.json_ and the one the app is actually running.

	````
	manifoldjs http://localhost:55804/ -p windows10
	````

1. Navigate to the generated **OrderApp** folder using the **cd** command and run the solution by executing the following command

	````
	manifoldjs run windows10
	````

	![OrderApp running as a Hosted Web App](Images/order-app-windows.png?raw=true "OrderApp running as a Hosted Web App")

	_OrderApp running as a Hosted Web App_

1. You can explore the generated content. In order to build and submit the application to the store, review the instructions in the **Windows10-next-steps.md** document located inside the **windows10** folder.

<a name="Ex5Task2" ></a>
#### Task 2 - Adding toast and live tiles to your Hosted Web Application ####

_Hosted Web Apps_ in _Windows 10_ have the same advantages as any other Windows app, which means you can take advantage of platform specific APIs such as [Live Tiles](https://msdn.microsoft.com/en-us/library/windows/apps/hh465377.aspx), [back button](https://msdn.microsoft.com/en-us/library/windows/apps/mt465734.aspx), [secondary pinning](https://msdn.microsoft.com/en-us/library/windows/apps/hh761489.aspx) and support for [Cortana interactions](https://msdn.microsoft.com/library/windows/apps/xaml/mt185598.aspx). Generally, users will expect the Store app to provide them with some additional functionality they can’t get in the browser, so it’s highly recommended you augment your web app with some of these features when moving outside the browser and into the Hosted Web App. You don’t need to fork your code to do this. Just like any web API, Windows 10 APIs can be feature detected.

In this task, you will add live tiles and toast notifications support to your site to be used from inside the Hosted Web App.

1. Switch back to **Visual Studio**. In **Solution Explorer**, right-click the **js** folder located under **wwwroot** and select **Add | New Item...**. Select **JavaScript File** under the **DNX | Client-Side** menu, change the name to _windows-features.js_ and click **Add**.

1. Add the following code snippet to perform a feature test to make sure we only execute the calls for Windows 10 APIs when we are actually inside a Windows 10 app.

	(Code Snippet - _FrontEndDev - Ex5 - WindowsFeatureTest_)
	<!-- mark:1-5 -->
	````JavaScript
	(function (window) {
		 if (window.Windows) {
			  // add in Windows features...
		 }
	}(window));
	````

1. Add the following function above the `if` statement. This function will create and display a sample toast notification.

	(Code Snippet - _FrontEndDev - Ex5 - AddToastNotification_)
	<!-- mark:1-18 -->
	````JavaScript
    function AddToastNotification() {
        var notifications = window.Windows.UI.Notifications;

        // Generate the toast notification template
        var template = notifications.ToastTemplateType.toastText01;
        var toastXml = notifications.ToastNotificationManager.getTemplateContent(template);

        // Set the toast text
        var toastTextElements = toastXml.getElementsByTagName("text");
        toastTextElements[0].appendChild(toastXml.createTextNode("Order App Toast notification!"));

        // Create the toast notification based on the XML content you've specified
        var toast = new notifications.ToastNotification(toastXml);

        // Send the toast notification
        var toastNotifier = notifications.ToastNotificationManager.createToastNotifier();
        toastNotifier.show(toast);
    }
	````

1. Add the following function below _AddToastNotification_. This function will add a sample live tile.

	(Code Snippet - _FrontEndDev - Ex5 - AddLiveTile_)
	<!-- mark:1-31 -->
	````JavaScript
    function AddLiveTile() {
        var notifications = window.Windows.UI.Notifications;

        var template = notifications.TileTemplateType.tileWide310x150Text01;
        var tileXml = notifications.TileUpdateManager.getTemplateContent(template);

        // Supply text content for your notification
        var tileTextAttributes = tileXml.getElementsByTagName("text");
        tileTextAttributes[0].appendChild(tileXml.createTextNode("OrderApp"));
        tileTextAttributes[1].appendChild(tileXml.createTextNode("Live tile"));

        // Include notification bindings for multiple tile sizes in the payload
        var squareTemplate = notifications.TileTemplateType.tileSquare150x150Text04;
        var squareTileXml = notifications.TileUpdateManager.getTemplateContent(squareTemplate);

        var squareTileTextAttributes = squareTileXml.getElementsByTagName("text");
        squareTileTextAttributes[0].appendChild(squareTileXml.createTextNode("OrderApp - Tile notification!"));

        var node = tileXml.importNode(squareTileXml.getElementsByTagName("binding").item(0), true);
        tileXml.getElementsByTagName("visual").item(0).appendChild(node);

        // Create the notification based on the XML content you've specified
        var tileNotification = new notifications.TileNotification(tileXml);

        // Set an expiration time for the notification
        var currentTime = new Date();
        tileNotification.expirationTime = new Date(currentTime.getTime() + 600 * 1000);

        // Send the notification to the app tile
        notifications.TileUpdateManager.createTileUpdaterForApplication().update(tileNotification);
    }
	````

1. Update the content of the feature test added before, by replacing the `// add in Windows features...` comment with the call to the _AddToastNotification_ and _AddLiveTile_ functions.

    ````JavaScript
    if (window.Windows) {
        AddToastNotification();
        AddLiveTile();
    }
    ````

1. Open the _Layout.cshtml_ file located at the **Views/Shared** folder and add the following line at the end of the **body** tag to include the reference to the _windows.js_ file you created.

	````HTML
	<script src="~/js/windows-features.js"></script>
	````

1. Open the _manifest.json_ file and verify that the following line is present. This property enables the Windows application to have access to the native APIs.

	````JSON
	"mjs_api_access": [
		{
			"match": "http://localhost:55804/*",
			"access": "all",
			"platform": "windows10"
		}
	],
	````

1. Run the web application using **Ctrl + F5** and don't stop it as you will need the app running for the following steps.

1. Back in the **Command Prompt**, make sure that you are located in the folder that ManifoldJS generated and run the solution by executing the following command.

	````
	manifoldjs run windows10
	````

1. Once the application starts, you should see the toast notification. Each time you navigate to a new page the code will be executed again, so you will be able to see the notification.

	![OrderApp Toast notification](Images/order-app-toast-notification.png?raw=true "OrderApp Toast notification")

	_OrderApp Toast notification_

1. Pin the application to your start menu to see the live tile.

	![OrderApp Live Tile](Images/order-app-live-tile.png?raw=true "OrderApp Live Tile")

	_OrderApp Live Tile_

---

<a name="Summary" ></a>
## Summary ##

By completing this module, you should have:

- Worked with Single Page Applications using Angular 2
- Integrated HTTP services using ASP.NET Core web api's
- Tested your applications for web standards compliance with the Vorlon.js Edge extension
- Packaged your site as an app using ManifoldJS

> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.
