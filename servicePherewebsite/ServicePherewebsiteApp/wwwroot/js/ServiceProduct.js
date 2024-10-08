

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/serviceproduct/getall',
            dataSrc: function (data) {
                console.log("Fetched data:", data);
                return data.data;
            },
            error: function (xhr, error, code) {
                console.log("Error fetching data:", error);
            }
        },
        "columns":[
            { data: 'name',"width":"15%" },
            { data: 'description', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            { data: 'location', "width": "15%" },
            {
                "data": null,
                "defaultContent": '<div class="w-75 btn-group" role="group">'
                    + '<button class="btn btn-primary mx-2 editBtn">Edit</button>'
                    + '<button class="btn btn-danger mx-2 deleteBtn">Delete</button>'
                    + '</div>',
                "width": "20%"

            }
        ]
    });

}

