using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxFileManager;

/// <summary>
/// Summary description for FileManagerAccessRuleHelper
/// </summary>
public class FileManagerAccessRuleHelper
{
	ASPxFileManager fm;
	private string compoundUserRole;

	public string CompoundUserRole {
		get {
			if (compoundUserRole == null) {
				compoundUserRole = String.Join("|", System.Web.Security.Roles.GetRolesForUser());
			}
			return compoundUserRole;
		}
	}

	public FileManagerAccessRuleHelper(ASPxFileManager fileManager) {
		this.fm = fileManager;
	}
	public void CreateRuleForCompoundRole() {
		string[] userRoles = System.Web.Security.Roles.GetRolesForUser();
		List<FileManagerAccessRuleBase> roleAccessRules = new List<FileManagerAccessRuleBase>();
		AccessRulesCollection currentAccessRules = fm.SettingsPermissions.AccessRules;

		foreach (string userRole in userRoles)
			roleAccessRules.AddRange(currentAccessRules.FindAll(r => String.Compare(r.Role, userRole, true) == 0));

		CreateCompoundRoleRules(roleAccessRules);

	}
	private void CreateCompoundRoleRules( List<FileManagerAccessRuleBase> userRolesRuleList) {
		foreach (FileManagerAccessRuleBase role in userRolesRuleList) {
			fm.SettingsPermissions.AccessRules.Add(CreateCompoundRoleRule(role));
		}
	}

	private FileManagerAccessRuleBase CreateCompoundRoleRule(FileManagerAccessRuleBase source) {
		FileManagerAccessRuleBase rule;
		if (source is FileManagerFolderAccessRule)
			rule = new FileManagerFolderAccessRule();
		else
			rule = new FileManagerFileAccessRule();

		rule.Assign(source);
		rule.Role = CompoundUserRole;
		return rule;
	}
}