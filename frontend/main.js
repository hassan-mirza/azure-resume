window.addEventListener("DOMContentLoaded", (e) => {
    getVisitCount();
});

const functionApi = "https://hmresumecounter.azurewebsites.net/api/GetResumeCounter?code=l8irBj8vfkNaVgzM27xfv4gxFoE2O2WwGFXUJJ9SjtHlc9w739FZGg==";
//const functionApi = "http://localhost:7071/api/GetResumeCounter";;

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