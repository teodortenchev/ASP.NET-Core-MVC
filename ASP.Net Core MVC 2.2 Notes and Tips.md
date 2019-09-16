# Forms

**Using display names from the model to populate labels automatically**
Can increase code re-usability as the names will have to be changed in only one place to reflect everywhere else. The below attribute will do the trick.

[Display(Name = "insertName")]
[DataType(DataType.MultilineText)]
public string Description { get; set; }

We can then have the following in the .cshtml

    <label asp-for="Description"></label>
Which will populate the label name as "insertName" in this case. The DataType attribute will change the type="" in the HTML, so that it doesn't have to be added manually to the code in the view. Useful for password fields for example.

You can also have 

**Ensuring valid form data is redisplayed to user if model is not valid**

    public IActionResult Anything(CreationInputModel input)...
        if (!ModelState.IsValid) 
        {
    	    return this.View(input)
        }

**Drop-down list from enum using HTML helper (no tag helper available yet)**

    <label asp-for="Type"></label>
    <select asp-for="Type" asp-items="@Html.GetEnumSelectList<EnumTypeHere>()">
    </select>


**Drop-down list from enumerable object**

    <select asp-for="Type" asp-items="IENUMERABLE_HERE"></select>
    
(SelectListItems type...)


# Security
To protect against **CSRF**, auto validation of the anti forgery token can be added as a filter. Can be done by adding the filter as an option in Startup -> ConfigureServices method. In this way all post actions in the controllers will have auto anti forgery token validation enabled.

    services.AddMvc(options =>
    {    
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());    
    })   
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


# Controllers

**Change the source of data binding in an action [From{source}]**

    public IActionResult Create([FromForm]CreateInputModel input)
    
FromForm will take the data only from the form. [FromQuery] will only look at the query params and so on.

**Parameter tampering protection / Change which properties to bind**

    public IActionResult Create([Bind("property1, property2, etc")]CreateInputModel input)
    
Or we can exclude a property and bind all others.

    public ActionResult Edit([Bind(Exclude = "Age")] ...)

![enter image description here](blob:https://imgur.com/1096573e-5c81-419b-a847-a608ee11c805)
