window.addEventListener("DOMContentLoaded", (e) => {
    getVisitCount();
});

const functionApi = "http://localhost:7071/api/GetResumeCounter";

const getVisitCount = () => {
    let count = 30;

    fetch(functionApi).then(response => {
        return response.json();
    }).then(response => {
        console.log("website called api");
        count = response.counter;
        console.log(count);
    }).catch(error => {
        console.log(error);
    });

    return count;
}