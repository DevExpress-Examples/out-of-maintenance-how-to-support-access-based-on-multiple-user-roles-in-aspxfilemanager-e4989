Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.ASPxFileManager

''' <summary>
''' Summary description for FileManagerAccessRuleHelper
''' </summary>
Public Class FileManagerAccessRuleHelper
	Private fm As ASPxFileManager
	Private compoundUserRole_Renamed As String

	Public ReadOnly Property CompoundUserRole() As String
		Get
			If compoundUserRole_Renamed Is Nothing Then
				compoundUserRole_Renamed = String.Join("|", System.Web.Security.Roles.GetRolesForUser())
			End If
			Return compoundUserRole_Renamed
		End Get
	End Property

	Public Sub New(ByVal fileManager As ASPxFileManager)
		Me.fm = fileManager
	End Sub
	Public Sub CreateRuleForCompoundRole()
		Dim userRoles() As String = System.Web.Security.Roles.GetRolesForUser()
		Dim roleAccessRules As New List(Of FileManagerAccessRuleBase)()
		Dim currentAccessRules As AccessRulesCollection = fm.SettingsPermissions.AccessRules

		For Each userRole As String In userRoles
			roleAccessRules.AddRange(currentAccessRules.FindAll(Function(r) String.Compare(r.Role, userRole, True) = 0))
		Next userRole

		CreateCompoundRoleRules(roleAccessRules)

	End Sub
	Private Sub CreateCompoundRoleRules(ByVal userRolesRuleList As List(Of FileManagerAccessRuleBase))
		For Each role As FileManagerAccessRuleBase In userRolesRuleList
			fm.SettingsPermissions.AccessRules.Add(CreateCompoundRoleRule(role))
		Next role
	End Sub

	Private Function CreateCompoundRoleRule(ByVal source As FileManagerAccessRuleBase) As FileManagerAccessRuleBase
		Dim rule As FileManagerAccessRuleBase
		If TypeOf source Is FileManagerFolderAccessRule Then
			rule = New FileManagerFolderAccessRule()
		Else
			rule = New FileManagerFileAccessRule()
		End If

		rule.Assign(source)
		rule.Role = CompoundUserRole
		Return rule
	End Function
End Class