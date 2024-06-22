<table style="width: 900px">
    <tr>
        <td style="width: 900px" width="900px;">
            <p>Dear #EMP_NAME#</p>
            <br />
            <p>Your procurement request #REQUEST_TYPE# with details below has been submitted and pending approvals. </p>
            <br />
            <br />
            <div style="font-weight: bold; font-size: 14px;">REQUEST Details:</div>
            <p>Request Date: #REQUEST_DATE#</p>
            <p>Note: #REMAKRS#</p>
            <p>Requested Items</p>
            
            <table style="width: 900px" width="900px;">
                <tr>
                    <td style="width: 900px; background: #703199; height: 10px; color: #FFFFFF" heigt="10px;" width="900px;"></td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 900px" width="900px;border:1px solid #000000">
                            <tr>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Name</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Unit</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Quantity</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Notes</td>
                            </tr>
                            #ITEMS#                                  
                        </table>
                    </td>
                </tr>
            </table>

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