/*
function GetData(event) {
    event.preventDedault();

    var studentCode = document.getElementById("studentCode");
    var studentName = document.getElementById("studentName");
    var studentGender = document.getElementById("studentGender");
    var studentPhone = document.getElementById("studentPhone");
    var studentEmail = document.getElementById("studentEmail");
    var myTable = document.getElementById("myTable");

    myTable.innerHTML += `
        <tr>
            <td>${studentCode.value}</td>
            <td>${studentName.value}</td>
            <td>${studentGender.value}</td>
            <td>${studentPhone.value}</td>
            <td>${studentEmail.value}</td>
            <td><button class="btn btn-primary" data-toggle="modal" data-target="#formStudentUpdate">Sửa</button></td>
            <td><button class="btn btn-danger" data-toggle="modal" data-target="#confirmDeleteStudent">Xóa</button></td>
        </tr>
    `
}
*/