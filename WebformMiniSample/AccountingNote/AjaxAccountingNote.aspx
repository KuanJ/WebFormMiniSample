<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxAccountingNote.aspx.cs" Inherits="AccountingNote.AjaxAccountingNote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>使用 AJAX 更新 AccountingNote</title>
    <script src="Scripts/jQuery-min-3.6.0.js"></script>
    <script>
        $(function () {

            //存取值至資料庫
            $("#btnSave").click(function () {
                var id = $("hfID").val();

                var actType = $("#ddlActType").val();
                var amount = $("#txtAmount").val();
                var caption = $("#txtCaption").val();
                var desc = $("#txtDesc").val();

                if (id) {
                    $.ajax({
                        url: "https://localhost:44316/Handlers/AccountingNoteHandler.ashx?actionName=update",
                        type: "POST",
                        data: {
                            "Caption": caption,
                            "Amount": amount,
                            "ActType": actType,
                            "Body": desc
                        },
                        success: function (result) {
                            alert("更新成功");
                        }
                    });
                }
                else {
                    $.ajax({
                        url: "https://localhost:44316/Handlers/AccountingNoteHandler.ashx?actionName=create",
                        type: "POST",
                        data: {
                            "Caption": caption,
                            "Amount": amount,
                            "ActType": actType,
                            "Body": desc
                        },
                        success: function (result) {
                            alert("更新成功");
                        }
                    });
                }
            });


            $(document).on("click", ".btnReadData", function () {
                var td = $(this).closest("td");
                var hf = td.find("input:hidden.hfRowID");

                var rowID = hf.val();

                $.ajax({
                    url: "https://localhost:44316/Handlers/AccountingNoteHandler.ashx?actionName=query",
                    type: "POST",
                    data: {
                        "ID": rowID,
                    },
                    success: function (result) {
                        $("#hfID").val(result["ID"]);
                        $("#ddlActType").val(result["ActType"]);
                        $("#txtAmount").val(result["Amount"]);
                        $("#txtCaption").val(result["Caption"]);
                        $("#txtDesc").val(result["Body"]);

                        $("#divEditor").show(300);

                    }
                });
            });

            $(".btnReadData").bind("click", function () {
                var td = $(this).closest("td");
                var hf = td.find("input:hidden.hfRowID");

                var rowID = hf.val();

                $.ajax({
                    url: "https://localhost:44316/Handlers/AccountingNoteHandler.ashx?actionName=query",
                    type: "POST",
                    data: {
                        "ID": rowID,
                    },
                    success: function (result) {
                        $("#hfID").val(result["ID"]);
                        $("#ddlActType").val(result["ActType"]);
                        $("#txtAmount").val(result["Amount"]);
                        $("#txtCaption").val(result["Caption"]);
                        $("#txtDesc").val(result["Body"]);
                    }
                });
            });
            //點擊後將新增的窗口顯示
            $("#btnAdd").click(function () {
                $("#hfID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtDesc").val('');

                $("#divEditor").show(300);
            });
            //點擊後將新增的窗口隱藏
            $("#btnCancle").click(function () {
                $("#hfID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtDesc").val('');

                $("#divEditor").hide(300);
            });

            $("#divEditor").hide();

            $.ajax({
                url: "https://localhost:44316/Handlers/AccountingNoteHandler.ashx?ActionName=list",
                type: "GET",
                data: {},
                success: function (result) {
                    var table = '<table border="1">';
                    table += '<tr> <th>Caption</th> <th>Amount</th> <th>ActType</th> <th>CreateDate</th> <th>Act</th> </tr>';

                    for (var i = 0; i < result.length; i++) {
                        var obj = result[i];
                        var htmlText =
                            `<tr>
                                <td>${obj.Caption}</td>
                                <td>${obj.Amount}</td>
                                <td>${obj.ActType}</td>
                                <td>${obj.CreateDate}</td>
                                <td>
                                    <input type="hidden" class="hfRowID" value="${obj.ID}" />

                                    <button type="button" class="btnReadData">
                                        <img src="Images/search.png" width="20" height="20"/>
                                    </button>
                                </td>
                            </tr>`;
                        table += htmlText;
                    }

                    table += "</table>";
                    $("#divAccountingList").append(table);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divEditor">
            <input type="hidden" id="hfID" />
            <table>
                <tr>
                    <td>
                        <!--這裡放主要內容-->
                        Type: 
                        <select id="ddlActType">
                            <option value="0">支出</option>
                            <option value="1">收入</option>
                        </select>
                        <br />
                        Amount: 
                        <input type="number" id="txtAmount" />
                        <br />
                        Caption: 
                        <input id="txtCaption" />
                        <br />
                        Desc:
                        <textarea id="txtDesc" rows="5" cols="60"></textarea>
                        <br />
                        <button type="button" id="btnSave">SAVE</button>
                        <button type="button" id="btnCancle">Cancle</button>
                    </td>
                </tr>
            </table>
        </div>

        <button type="button" id="btnAdd">ADD</button>
        <div id="divAccountingList"></div>
    </form>
</body>
</html>
