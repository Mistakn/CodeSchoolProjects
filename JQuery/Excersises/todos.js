$(document).ready(function () {
    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/todos',
        contentType: "application/json",
        dataType: 'json',
        type: 'get',
        success: function (result) {
            console.log(result);

            var todoTable = $('#toDoTable');

            result.forEach(todo => {
                let todoId = todo.id;
                let todoTitle = todo.title;
                let todoUserId = todo.userId;
                let todoCompleted = todo.completed;

                let row = `<tr>
                <td>${todoId}</td>
                <td>${todoTitle}</td>
                <td>${todoUserId}</td>
                <td class="${todoCompleted ? 'completed' : 'incomplete'}">${todoCompleted}</td>
            </tr>`;

                todoTable.append(row);
            });

            $("td.completed").parent().css("background-color", "green");
            $("td.incomplete").parent().css("background-color", "red");
        },
        failure: function (result) {
            console.log('Something went wrong');
        }
    })
});
