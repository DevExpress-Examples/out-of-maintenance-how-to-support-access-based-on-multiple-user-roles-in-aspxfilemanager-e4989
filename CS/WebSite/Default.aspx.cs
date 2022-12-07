using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class Default : System.Web.UI.Page {
protected void ASPxFileManager1_Init(object sender, EventArgs e) {

	ASPxFileManager fm = sender as ASPxFileManager;

	//simple single-role solution
	//fm.SettingsPermissions.Role = System.Web.Security.Roles.GetRolesForUser()[0];

	
	//multiple roles solution
	FileManagerAccessRuleHelper accessRuleHelper = new FileManagerAccessRuleHelper(fm);
	fm.SettingsPermissions.Role = accessRuleHelper.CompoundUserRole;
	accessRuleHelper.CreateRuleForCompoundRole();
	
}

}