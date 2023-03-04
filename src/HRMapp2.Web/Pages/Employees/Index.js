$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Employees/ViewModal');

    var l = abp.localization.getResource('HRMapp2');
    var queryName = "";
    var employeeService = hRMapp2.employees.employee;

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
          /*  searchParams: "queryName",*/
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employeeService.getList),
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
                                        return "Are you sure to delete the employee '" + data.record.employeeName  +"'?";
                                    },
                                    action: function (data) {
                                        employeeService
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
                    title: 'Employee Name',
                    data: "employeeName"
                },
                {
                    title: 'Department Name',
                    data: "departmentId",
                    render: function (data) {
                        return l('Enum:DepartmentId:'+data);
                        
                    }
                },
                /*{
                    title: 'Employee Address',
                    data: "employeeAddress"
                },
                {
                    title: 'Employee Supervisor',
                    data: "employeeSupervisor",
                  
                },
                {
                    title: 'Employee Sex',
                    data: "employeeSex"
                },
                {
                    title: 'Employee DOB',
                    data: "employeeDob"
                },
                {
                    title: 'Employee Weekly Hours',
                    data: "employeeWeeklyHours"
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

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});