<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateHTML.aspx.cs" Inherits="Pipewellservice.EmailTemplateHTML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 900px;border:0px">
            <tr>
                <td style="width: 900px" width="900px;">
                    <p>Dear #EMP_NAME#</p>
                    <br />
                    <p>Your leave request #LEAVE_TYPE# with details below has been submitted and pending approvals. </p>
                    <br />
                    <br />
                    <div style="font-weight: bold; font-size: 14px;">Leave Details:</div>
                    <p>Leave Start Date: #START_DATE#</p>
                    <p>Return to Work Date: #END_DATE#</p>
                    <p>Number of Leave Days:#DAYS#</p>

                    <br />
                    <br />
                    <table style="width: 900px" width="900px;">
                        <tr>
                            <td style="width: 900px; background: #703199; height: 10px; color: #FFFFFF" heigt="10px;" width="900px;"></td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 900px" width="900px;border:1px solid #000000">
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Employee Name</td>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Position</td>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Status</td>
                                    </tr>
                                    #APPROVALS#
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table style="width: 900px;border:0px">
            <tr>
                <td style="width: 900px" width="900px;">
                    <p>Dear #APPROVE_NAME#</p>
                    <br />
                    <p>#EMP_NAME# #EMP_ID#  has requested #LEAVE_TYPE#. </p>
                    <br />
                    <br />
                    <div style="font-weight: bold; font-size: 14px;">Leave Details:</div>
                    <p>Leave Start Date: #START_DATE#</p>
                    <p>Return to Work Date: #END_DATE#</p>
                    <p>Number of Leave Days:#DAYS#</p>
                    <br />
                    <br />
                    <a href="#PORTAL_LINK#">Click here</a> to process to approvals 
                    <br />
                    <table style="width: 900px" width="900px;">
                        <tr>
                            <td style="width: 900px; background: #703199; height: 10px; color: #FFFFFF" heigt="10px;" width="900px;"></td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 900px" width="900px;border:1px solid #000000">
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Employee Name</td>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Position</td>
                                        <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Status</td>
                                    </tr>
                                    #APPROVALS#
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        Dear "Approver Name",  
        "Employee Name" "Employee ID No." has requested "Leave Type". 

        Leave Details: 
        Leave Start Date: DD-MM-YY
        Return to Work Date: DD-MM-YY
        Number of Leave Days:

    </form>
</body>
</html>
