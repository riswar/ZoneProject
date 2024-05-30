$(document).ready(function () {
    new DataTable('#dtDNSList', {
        ajax: {
            url: 'zone/GetDNSRecords',
            type: 'POST'
        },
        columns: [
            { data: 'id' },
            { data: 'zone' },
            { data: 'fqdn' },
            { data: 'recordName' },
            { data: 'type' },
            { data: 'ttl' },
            { data: 'data' },
            {
                'data': 'id',
                "render": function (data, type, row, meta) {
                    return '<a href="zone/UpdateDNS/' + data + '"><button class="btn btn-success">Update</button></a>&nbsp;<a href="zone/DeleteDns/' + data + '"><button class="btn btn-danger">Delete</button></a>';
                }
            }
        ],
        columnDefs: [
            {
                target: 0,
                visible: true,
                searchable: false
            },
            {
                target: 3,
                sorting: false
            },
            {
                target: 4,
                sorting: false
            },
            {
                target: 5,
                sorting: false
            },
            {
                target: 6,
                sorting: false
            },
            {
                target: 7,
                sorting: false
            }
        ],
        processing: true,
        serverSide: true
    });
});

$('#ddlZoneId').change(function () {

    let search = $('#ddlZoneId option:selected').text();
    if ($('#ddlZoneId').val() == "")
        search = "";

    let dataTableWidget = $('#dtDNSList').DataTable();
    dataTableWidget.search(search).draw();
});

function onClickDNSNavigation(loc) {
    if ($('#ddlZoneId').val() == "")
    {      
        alert("Please select Zone!");
        return;
    }
    window.location.href = "Zone/" + loc + "/" + $('#ddlZoneId').val();
}