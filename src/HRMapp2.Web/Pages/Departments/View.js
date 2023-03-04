$(function () {
    
    var employeeService = hRMapp2.employees.employee;
    var l = abp.localization.getResource('HRMapp2');

    var dataTable = $('#ViewEmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employeeService.getList),
            columnDefs: [
                
                   
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
                {
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
                }


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
    
});