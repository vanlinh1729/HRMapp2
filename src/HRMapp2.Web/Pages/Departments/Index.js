$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Departments/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Departments/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Departments/ViewModal');

    var departmentService = hRMapp2.departments.department;

    var dataTable = $('#DepartmentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(departmentService.getList),
            columnDefs: [
                {
                    title: 'Actions',
                    rowAction: {
                        items:
                            [
                                {   
                                    text: 'Edit',
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: 'View',
                                    action: function (data) {
                                        viewModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: 'Delete',
                                    confirmMessage: function (data) {
                                        return "Are you sure to delete the department '" + data.record.departmentName  +"'?";
                                    },
                                    action: function (data) {
                                        departmentService
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info("Successfully deleted!");
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: 'Department Name',
                    data: "departmentName"
                },
                {
                    title: 'Department Manager',
                    data: "departmentManager"
                },
               /* {
                    title: 'Manager Start Date',
                    data: "managerStartDate",*/
                    /*render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }*/
               /* },
                {
                    title: 'Department Location',
                    data: "departmentLocation"
                }
               */
                
                /*{
                    title: 'ProjectNames',
                    data: "projectNames",
                    render: function (data) {
                        return data.join(", ");
                    }
                },
                {
                    title: 'EmployeeNames',
                    data: "employeeNames",
                    render: function (data) {
                        return data.join(", ");
                    }
                }*/
                
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDepartmentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});