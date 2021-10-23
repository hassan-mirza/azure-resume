window.addEventListener("DOMContentLoaded", (e) => {
    getVisitCount();
});

const functionApi = "";

const getVisitCount = () => {
    let count = 30;

    fetch(functionApi).then(response => {
        return response.json;
    }).then(response => {
        console.log("website called api");
        count = response.count;
    }).catch(error => {
        console.log(error);
    });

    return count;
}