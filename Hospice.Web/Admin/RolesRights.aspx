<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RolesRights.aspx.cs" Inherits="Hospice.Web.Admin.RolesRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
.chkhead{font-size: 15px;
    }
    .chkhead label{padding-left: 5px;}
</style>
    <script language="javascript" type="text/javascript">

           /* Author- Nitin Tiwari
              Date-   17-Jan-2009
              Desc-   Check if View is selected then only make possible to check create  */

     function ViewIsChecked(grdID,chdID)
     {

        var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	     var Tab1= document.getElementById(chdID);
	     var _KayValue=Tab1.parentElement.KeyValue;
           // alert(_KayValue);
	        for(var i=0; i<checkBoxes.length;i++)
	        {
	            var chkBox = checkBoxes[i]; 
	            
	             if(chkBox.parentElement.flagType=="CreateReport")
	             {
                     if(chkBox.parentElement.KeyValue==_KayValue)
                     {
                        if(Tab1.checked==true)
                         {
                           chkBox.parentElement.disabled=false;
                           chkBox.disabled=false;
                         }
                         else
                         {
                           chkBox.checked=false;
                           chkBox.disabled=true;
                         }
                     }
	             }
	        }	            	        	
	           	
     }
     
     function ViewIsCheckedReport(grdID,chdID)
     {

        var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	     var Tab1= document.getElementById(chdID);
	     //var _KayValue=Tab1.parentElement.KeyValue;
	     var _KayValue = Tab1.parentNode.attributes.KeyValue.nodeValue;
           // alert(_KayValue);
           for (var i = 0; i < checkBoxes.length; i++) {
        var chkBox = checkBoxes[i];

        if (chkBox.parentNode.attributes.flagType.nodeValue != "View") {
            if (chkBox.parentNode.attributes.KeyValue != undefined) {
                if (chkBox.parentNode.attributes.KeyValue.value == _KayValue) {
                    if (Tab1.checked == true) {

                        if (chkBox.disabled) {
                            chkBox.parentElement.disabled = false;
                            chkBox.disabled = false;
                        }
                    }
                    else {
                        chkBox.disabled = true;
                        chkBox.checked = false;
                    }
                }
            }
        }
    }
//	        for(var i=0; i<checkBoxes.length;i++)
//	        {
//	            var chkBox = checkBoxes[i]; 
//	            
//	             if(chkBox.parentElement.flagType !="View")
//	             {
//                     if(chkBox.parentElement.KeyValue==_KayValue)
//                     {
//                        if(Tab1.checked==true)
//                         {
//                          
//                            if(chkBox.disabled)
//                            {
//                             chkBox.parentElement.disabled=false;
//                             chkBox.disabled=false;
//                            }
//                         }
//                         else
//                         {
//                           chkBox.disabled=true;
//                           chkBox.checked=false;
//                         }
//                     }
//	             }
//	        }	            	        	
	           	
     }
     
     

/*   Rights for Repots */

function CheckUncheckViewReport(grdID,e)
{
    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
    //var hedCheck = event.srcElement;
    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
   	  for(var i=0; i<checkBoxes.length;i++)
   	    {	 	        
            var chkBox = checkBoxes[i];	            
             if(chkBox.type.toString().toLowerCase()=="checkbox")
              {
                var parent = chkBox.parentElement; 
                //if(parent.disabled ==false)
                if (chkBox.parentNode.attributes.flagType.value == "ViewReport")
                  {
                   //if(chkBox.parentElement.flagType=="ViewReport")
                     //{
                      chkBox.checked = hedCheck.checked;             
                     //}
                     
                       /* Author- Nitin Tiwari
                          Date-   17-Jan-2009
                          Desc-   Check if View is selected then only make possible to check create  */

                     if(hedCheck.checked)
                     {
                         //if(chkBox.parentElement.flagType=="CreateReport")
                         if (chkBox.parentNode.attributes.flagType.value == "CreateReport") 
                         {
                          chkBox.disabled = false;                
                         }
                     }
                     else
                     {
                        //if(chkBox.parentElement.flagType=="CreateReport")
                        if (chkBox.parentNode.attributes.flagType.value == "CreateReport")
                         {
                          chkBox.disabled = true;
                          chkBox.checked=false;                
                         }
                     }
                  }
             }
        }	         	        
 }		
      
      function CheckOthersViewReport(grdID,e){
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=0; i<checkBoxes.length;i++){
	        
	            var chkBox = checkBoxes[i];
	             
	            //if(chkBox.parentElement.flagType=="ViewReport")
	            if (chkBox.parentNode.attributes.flagType.value == "ViewReport")
	            {
	                if(chkBox.type.toString().toLowerCase()=="checkbox")
	                {
	                    if(found==0)
	                    {
	                    ParentCheckBox = chkBox; 
	                    found++;
	                    }
    	                	                
	                   if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase())
	                   {
    	                   
	                            if(chkBox.checked != CheckFor)
	                            {
                                    diff=true;
                                    break;
                                }
	                   }
	                }	         
	            }   	        
	        }	
	           
	  if(diff==false){
	        
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false){	   
	        if(ParentCheckBox.checked ==true) ParentCheckBox.checked= CheckFor;
	   }
	   
	    	
	}
      
        
function CheckUncheckCreateReport(grdID,e)
{
      
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
	    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
	    //var hedCheck = event.srcElement;
	    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	   	  for(var i=0; i<checkBoxes.length;i++)
	   	    {	 	        
	            var chkBox = checkBoxes[i];	            
	             if(chkBox.type.toString().toLowerCase()=="checkbox")
	              {
	                var parent = chkBox.parentElement; 
	                //if(parent.disabled ==false)
	                if (chkBox.parentNode.attributes.flagType.value == "CreateReport")
	                  {
	                   //if(chkBox.parentElement.flagType=="CreateReport")
	                     //{ 
	                       if(chkBox.disabled==false)
	                       chkBox.checked = hedCheck.checked;                
	                     //}
	                  }
	             }
	        }	         	        
 }	



	function CheckOthersCreateReport(grdID,e)
	{
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=0; i<checkBoxes.length;i++)
	        {
	        
	            var chkBox = checkBoxes[i]; 
	             if(chkBox.parentElement.flagType=="CreateReport")
	             {

	            if(chkBox.type.toString().toLowerCase()=="checkbox")
	            {
	             
	                if(found==0)
	                {
	                ParentCheckBox = chkBox; 
	                found++;
	                }
	                	                
	               if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase())
	               {
	                   
	                        if(chkBox.checked != CheckFor)
	                        {
                                diff=true;
                                break;
                            }
	               }
	            }
	          }	            	        
	        }	
	           
	  if(diff==false)
	  {  
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false)
	   {	 
	        if(ParentCheckBox.checked ==true) ParentCheckBox.checked= CheckFor;
	   }
	   
	    	
	}
///////////  for general  rights

function CheckUncheckView(grdID,e)
{
      
    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
    //var hedCheck = event.srcElement;
    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
   	  for(var i=0; i<checkBoxes.length;i++)
   	    {	 	        
            var chkBox = checkBoxes[i];	            
             if(chkBox.type.toString().toLowerCase()=="checkbox")
              {
                var parent = chkBox.parentElement; 
////                if(parent.disabled ==false)
////                  {
////                    if(chkBox.parentElement.flagType=="View")
                     if (chkBox.parentNode.attributes.flagType.value == "View")
                     {
                        chkBox.checked = hedCheck.checked;                
                     }
                     
                     if(hedCheck.checked)
                     {
                         //if(chkBox.parentElement.flagType !="View")
                         if (chkBox.parentNode.attributes.flagType.value != "View") 
                         {
                          chkBox.disabled = false;                
                         }
                     }
                     else
                     {
                        //if(chkBox.parentElement.flagType !="View")
                        if (chkBox.parentNode.attributes.flagType.value != "View")
                         {
                          chkBox.disabled = true;
                          chkBox.checked=false;                
                         }
                     }
                  //}
             }
        }	         	        
 }		       

function CheckUncheckCreate(grdID,e)
{
      
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
	    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
	    //var hedCheck = event.srcElement;
	    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	   	  for(var i=0; i<checkBoxes.length;i++)
	   	    {	 	        
	            var chkBox = checkBoxes[i];	            
	             if(chkBox.type.toString().toLowerCase()=="checkbox")
	              {
	                var parent = chkBox.parentElement; 
	                //if(parent.disabled ==false)
	                  //{
	                   //if(chkBox.parentElement.flagType=="Create")
	                   if (chkBox.parentNode.attributes.flagType.value == "Create") 
	                     {
	                     chkBox.checked = hedCheck.checked;                
	                     }
	                  //}
	             }
	        }	         	        
 }	
 
 function CheckUncheckEdit(grdID,e)
{
      
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
	    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
	    //var hedCheck = event.srcElement;
	    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	   	  for(var i=0; i<checkBoxes.length;i++)
	   	    {	 	        
	            var chkBox = checkBoxes[i];	            
	             if(chkBox.type.toString().toLowerCase()=="checkbox")
	              {
	                var parent = chkBox.parentElement; 
	                //if(parent.disabled ==false)
	                  //{
	                   //if(chkBox.parentElement.flagType=="Edit")
	                    if (chkBox.parentNode.attributes.flagType.value == "Edit")
	                     {
	                     chkBox.checked = hedCheck.checked;                
	                     }
	                  //}
	             }
	        }	         	        
 }	
 
 function CheckUncheckDelete(grdID,e)
{
      
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];	    	 
	    var checkBoxes = Tab.getElementsByTagName("INPUT"); 
	    //var hedCheck = event.srcElement;
	    var hedCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	   	  for(var i=0; i<checkBoxes.length;i++)
	   	    {	 	        
	            var chkBox = checkBoxes[i];	            
	             if(chkBox.type.toString().toLowerCase()=="checkbox")
	              {
	                var parent = chkBox.parentElement; 
	                //if(parent.disabled ==false)
	                  //{
	                   //if(chkBox.parentElement.flagType=="Delete")
	                   if (chkBox.parentNode.attributes.flagType.value == "Delete")
	                     {
	                     chkBox.checked = hedCheck.checked;                
	                     }
	                  //}
	             }
	        }	         	        
 }	
 
 //
 
 function CheckOthersView(grdID,e){
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=0; i<checkBoxes.length;i++){
	        
	            var chkBox = checkBoxes[i]; 
	            if(chkBox.parentElement.flagType=="View")
	             {
	            if(chkBox.type.toString().toLowerCase()=="checkbox")
	            {
	                if(found==0)
	                {
	                ParentCheckBox = chkBox; 
	                found++;
	                }
	                	                
	               if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase())
	               {
	                   
	                        if(chkBox.checked != CheckFor)
	                        {
                                diff=true;
                                break;
                            }
	               }
	            }	
	          }            	        
	        }	
	           
	  if(diff==false)
	   {
	        
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false)
	   {	   
	        if(ParentCheckBox.checked ==true)
	         ParentCheckBox.checked= CheckFor;
	   }
	   
	    	
	}

	
	function CheckOthersCreate(grdID,e){
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=1; i<checkBoxes.length;i++)
	        {
	        
	            var chkBox = checkBoxes[i]; 
	            if(chkBox.parentElement.flagType=="Create")
	             {
	            if(chkBox.type.toString().toLowerCase()=="checkbox")
	            {
	                if(found==0)
	                {
	                ParentCheckBox = chkBox; found++;
	                }
	                	                
	               if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase())
	               {
	                   
	                        if(chkBox.checked != CheckFor)
	                        {
                                diff=true;
                                break;
                            }
	               }
	            }	
	         }            	        
	        }	
	           
	  if(diff==false)
	  {
	        
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false)
	   {	   
	        if(ParentCheckBox.checked ==true) 
	        ParentCheckBox.checked= CheckFor;
	   }
	   
	    	
}
	
	// Edit
	
	function CheckOthersEdit(grdID,e){
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=2; i<checkBoxes.length;i++){
	        
	            var chkBox = checkBoxes[i]; 
	            if(chkBox.parentElement.flagType=="Edit")
	            {
	            if(chkBox.type.toString().toLowerCase()=="checkbox"){
	                if(found==0){ParentCheckBox = chkBox; found++;}
	                	                
	               if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase()){
	                   
	                        if(chkBox.checked != CheckFor){
                                diff=true;
                                break;
                            }
	               }
	            }	
	         }            	        
	        }	
	           
	  if(diff==false){
	        
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false){	   
	        if(ParentCheckBox.checked ==true) ParentCheckBox.checked= CheckFor;
	   }    	
	}
	// Delete
	
	function CheckOthersDelete(grdID,e)
	{
	
	    var Tab= document.getElementById(grdID).getElementsByTagName("TBODY")[0];
	    
	    var checkBoxes = Tab.getElementsByTagName("INPUT");
	    
	    //var srcCheck = event.srcElement;
	    var srcCheck = e.srcElement == undefined ? e.currentTarget : e.srcElement;
	    var CheckFor = srcCheck.checked;
	    var diff = false;
	    var headerCheck;
	    
	    var ParentCheckBox ;
	    
	    var found =0;
	    	        
	        for(var i=3; i<checkBoxes.length;i++)
	        {
	        
	            var chkBox = checkBoxes[i]; 
	            if(chkBox.parentElement.flagType=="Delete")
	            {
	            if(chkBox.type.toString().toLowerCase()=="checkbox")
	            {
	                if(found==0)
	                {
	                ParentCheckBox = chkBox; found++;
	                }
	                	                
	               if(ParentCheckBox.id.toString().toLowerCase() != chkBox.id.toString().toLowerCase() && chkBox.id.toString().toLowerCase() != srcCheck.id.toString().toLowerCase())
	               {
	                   
	                        if(chkBox.checked != CheckFor)
	                        {
                                diff=true;
                                break;
                            }
	               }
	            }
	          }	            	        
	        }	
	           
	  if(diff==false)
	  {
	      ParentCheckBox.checked = CheckFor;	      
	   }
	   else if(CheckFor==false)
	   {	   
	        if(ParentCheckBox.checked ==true)
	         ParentCheckBox.checked= CheckFor;
	   }
	   
	    	
	}
</script>

     <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">Role Rightd</li>
			<li class="breadcrumb-item active">Add Role Rights</li>
		</ol>
	</div>
	<!-- Page header end -->

    <!-- Content wrapper start -->
	<div class="content-wrapper">

		<!-- Row start -->
		<div class="row gutters">
			<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
				<div class="card">
					<div class="card-header">
						<div class="card-title">Role Details</div>
					</div>
					<div class="card-body">
						<div class="row gutters">
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="inputEmail">Role Name</label>
									<asp:DropDownList ID="ddlRoleName" runat="server" CssClass="form-control"></asp:DropDownList>
								</div>
							</div>
							<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
								<div class="text-right">
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <a href="RoleListing" class="btn btn-info">Cancel</a>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>   
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
								</div>
							</div>
						</div>
                        <div class="row gutters">
                            <asp:GridView ID="grdRights" runat="server" Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="grdRights_PageIndexChanging" OnRowDataBound="grdRights_RowDataBound"    >
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="View" >
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                            <HeaderStyle HorizontalAlign="center" Width="100px" />
                            <HeaderTemplate>
                                <asp:CheckBox runat="Server" ID="chkHed" Text="View"  flagType="View"  CssClass="chkhead"/>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:CheckBox runat="Server" ID="chkItem" flagType="View" Checked='<%# HasRight(long.Parse(DataBinder.Eval(Container.DataItem,"Right_Id").ToString())) %>' KeyValue='<%# DataBinder.Eval(Container.DataItem,"Right_Id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Create">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                            <HeaderStyle HorizontalAlign="center" Width="100px" />
                            <HeaderTemplate>
                                <asp:CheckBox runat="Server" ID="chkHeadCreate" Text="Create" flagType="Create" CssClass="chkhead"/>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:CheckBox runat="Server" ID="chkCreate" flagType="Create" Enabled='<%# IsCheckedView(long.Parse(Eval("Create_Id").ToString())) %>' Checked='<%# HasCreatetRight(long.Parse(Eval("Create_Id").ToString())) %>' KeyValue='<%# DataBinder.Eval(Container.DataItem,"Create_Id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Edit">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                            <HeaderStyle HorizontalAlign="center" Width="100px" />
                            <HeaderTemplate>
                                <asp:CheckBox runat="Server" ID="chkhedEdit" Text="Edit" flagType="Edit"   CssClass="chkhead"/>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:CheckBox runat="Server" ID="chkEdit" flagType="Edit" Enabled='<%# IsCheckedView(long.Parse(Eval("Create_Id").ToString())) %>' Checked='<%# HasEditRight(long.Parse(Eval("Edit_Id").ToString())) %>' KeyValue='<%# DataBinder.Eval(Container.DataItem,"Edit_Id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Delete">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                            <HeaderStyle HorizontalAlign="center" Width="100px" />
                            <HeaderTemplate>
                                <asp:CheckBox runat="Server" ID="chkHedDelete" Text="Delete"  flagType="Delete" CssClass="chkhead"/>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:CheckBox runat="Server" ID="chkDelete" flagType="Delete"  Enabled='<%# IsCheckedView(long.Parse(Eval("Create_Id").ToString())) %>'  Checked='<%# HasDeleteRight(long.Parse(Eval("Delete_Id").ToString())) %>' KeyValue='<%# DataBinder.Eval(Container.DataItem,"Delete_Id") %>'   />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Rights" SortExpression="Right_Description">
                            <ItemTemplate>
                                <asp:Label ID="LblRights" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Right_Description") %>'  ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                        </div>
					</div>
				</div>
			</div>
			
		</div>
		<!-- Row end -->

	</div>
	<!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
