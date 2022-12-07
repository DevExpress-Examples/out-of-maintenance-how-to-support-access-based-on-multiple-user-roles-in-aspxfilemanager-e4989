Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class [Default]
	Inherits System.Web.UI.Page
Protected Sub ASPxFileManager1_Init(ByVal sender As Object, ByVal e As EventArgs)

	Dim fm As ASPxFileManager = TryCast(sender, ASPxFileManager)

	'simple single-role solution
	'fm.SettingsPermissions.Role = System.Web.Security.Roles.GetRolesForUser()[0];


	'multiple roles solution
	Dim accessRuleHelper As New FileManagerAccessRuleHelper(fm)
	fm.SettingsPermissions.Role = accessRuleHelper.CompoundUserRole
	accessRuleHelper.CreateRuleForCompoundRole()

End Sub

End Class