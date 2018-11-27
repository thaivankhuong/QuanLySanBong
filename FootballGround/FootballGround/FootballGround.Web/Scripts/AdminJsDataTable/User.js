$(function () {
    var objct = {
        "Name": "Co lo Quang ",
        "Age": 23
    }
 var table =  $('#TableId').DataTable(
     {
            "searching": true,
            "columnDefs": [
                { "orderable": false, "targets": [0, 1,2,3 ]}
            ],
            "processing": false, // for show progress bar cho thanh tiến trình hiển thị
            "serverSide": false, // for process server side cho phía máy chủ quy trìnhv
            "filter": true, // this is for disable filter (search box) this is for disable filter
            "orderMulti": false, // for disable multiple column at once để vô hiệu hóa nhiều cột cùng một lúc
            "pageLength": 25,
            //"columnDefs": [
            //    { "width": "5%", "targets": [0], "width": "20%", "targets": [1] },
            //    { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3] },
            //],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/UserManger/GetData",
                "type": "POST",
                "dataType": "JSON",
                "data": {
                    "Employeee": objct
                }
            },
            "columns": [
                
                { "data": "FirstName" },
                { "data": "LastName" },
                { "data": "Email" },
                { "data": "UserName" },
                {
                    "render": function (data, type, full, meta) {
                        return '<a class="btn btn-info" href="/Demo/Edit/' + full.Id + '">Edit</a> ' + "<a href='#' class='btn btn-danger' onclick=DeleteData('" + full.Id + "'); >Delete</a>";
                    }
                },
            ]
        });
 $('#TableId_filter input').unbind();
 $('#TableId_filter input').bind('keyup', function (e) {
     if (e.keyCode == 13) {
         table.search($(this).val()).draw();
     }
     else if ($(this).val() == "") {
         table.search($(this).val()).draw();
     }
 });
});
function DeleteData(CustomerID) {
    if (confirm("Are you sure you want to delete ...?")) {

    }
    else {
        return false;
    }
}

