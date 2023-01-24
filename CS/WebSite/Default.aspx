﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<dx:ASPxFileManager ID="ASPxFileManager1" runat="server" OnInit="ASPxFileManager1_Init">
		<Settings RootFolder="~\" ThumbnailFolder="~\Thumb\" />
		<SettingsPermissions>
			<AccessRules>
				<dx:FileManagerFolderAccessRule Browse="Deny" />
				<dx:FileManagerFolderAccessRule Browse="Allow" Role="admin" />
				<dx:FileManagerFolderAccessRule Browse="Allow" Role="moderator" Path="Moderator" />
				<dx:FileManagerFolderAccessRule Browse="Allow" Role="user" Path="user1" />
				<dx:FileManagerFolderAccessRule Browse="Allow" Role="user" Path="user2" />
				<dx:FileManagerFolderAccessRule Browse="Allow" Role="user" Path="user3" />
			</AccessRules>
		</SettingsPermissions>
	</dx:ASPxFileManager>
</asp:Content>

