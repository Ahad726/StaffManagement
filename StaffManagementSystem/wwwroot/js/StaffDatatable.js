$(document).ready(function () {
    $('#staffDatatable').DataTable({
        "ajax": "staff/ajaxmethod",
        "columns": [
            { "data": "staffName" },
            { "data": "phoneNumber" },
            { "data": "skillId" },
            { "data": "yearsExperience" },
            { "data": "staffId" },
        ]
    });
});