<!-- default file list -->
*Files to look at*:

* [FileManagerAccessRuleHelper.cs](./CS/WebSite/App_Code/FileManagerAccessRuleHelper.cs) (VB: [FileManagerAccessRuleHelper.vb](./VB/WebSite/App_Code/FileManagerAccessRuleHelper.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
<!-- default file list end -->
# How to support access based on multiple user roles in ASPxFileManager


<p>By default, ASPxFileManager supports only a single user role. If you use built-in ASP.NET membership and your users have only single roles, you can fill the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerFileManagerSettingsPermissions_AccessRulestopic"><u>FileManagerSettingsPermissions.AccessRules</u></a> collection (in control markup or in code behind) and assign a user role to the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxFileManagerFileManagerSettingsPermissions_Roletopic"><u>FileManagerSettingsPermissions.Role</u></a>  property:</p>

```cs
protected void ASPxFileManager1_Init(object sender, EventArgs e) {
	ASPxFileManager fm = sender as ASPxFileManager;
	fm.SettingsPermissions.Role = System.Web.Security.Role.GetRolesForUser()[0];
}
```

<p> </p>

```vb
Protected Sub ASPxFileManager1_Init(ByVal sender As Object, ByVal e As EventArgs)
	Dim fm As ASPxFileManager = TryCast(sender, ASPxFileManager)
	fm.SettingsPermissions.Role = System.Web.Security.Roles.GetRolesForUser()[0];
End Sub

```

<p>This is a very simple approach. However, it does not make sense if you want to provide access to ASPxFileManager items (file and folders) based on several user roles.</p><p>One of possible solutions is to generate corresponding rules at runtime. Since you know current user roles, you can implement some custom algorithm to generate AccessRules at runtime. On the other hand, implementation of this solution is not obvious and is a rather complex task. Especially, if you need to provide different access to file system on different pages of your site.</p><br />
<p>This example illustrates an alternative way. Create ASPxFileManager with a static collection of AccessRules (in markup or at runtime). In the <strong>ASPxFileManager.Init</strong> event handler, assign a 'compound' rule to the FileManagerSettingsPermissions.Role property and call the CreateRuleForCompoundRole method to generate AccessRules based on the 'static' rule list and current user roles. As a result, the FileManagerSettingsPermissions.AccessRules collection will contain 'static' rules (which do not make sense since we assigned a 'compound' role to the FileManagerSettingsPermissions.Role property) and rules for the 'compound' user role.</p><br />
<br />
<p>This example uses a default ASP.NET membership database. To keep database integrity, this example cannot be run online. Please download it and run on your local machine to see how it works.</p><p></p><p></p>

<br/>


