$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Employees/ViewModal');

    var l = abp.localization.getResource('HRMapp2');
    var query = () => {
        return {'queryName': $("#NameSearch").val()}
    }
    $("#NameSearch").on("input", (n) => {
        console.log("A")
        dataTable.ajax.reload();
    })

    var employeeService = hRMapp2.employees.employee;

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
          /*  searchParams: "queryName",*/
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employeeService.getList, query),
            columnDefs: [
                {
                    title: l('Employee:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Employee:Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Employee:View'),
                                    action: function (data) {
                                        viewModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Employee:Delete'),
                                    confirmMessage: function (data) {
                                        return "Bạn có muốn xoá nhân viên '" + data.record.employeeName  +"'?";
                                    },  
                                    action: function (data) {
                                        employeeService
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info("Xoá thành công!");
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Employee:Employee Name'),
                    data: "employeeName"
                },
                {
                    title: l('Employee:Department Name'),
                    data: "departmentName"
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