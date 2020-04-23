var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/ChangeLogs/GetAll/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "description", "width": "20%" },
            { "data": "reason", "width": "20%" },
            { "data": "affectedProductsAndProcesses", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/ChangeLogs/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete("/ChangeLogs/Delete/1")>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
} /*("/ChangeLogs/Delete?id=" + ${ data })*/