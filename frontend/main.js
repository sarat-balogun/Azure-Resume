window.addEventLisstner('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApi = "http://localhost:7071/api/GetResumeCounter";

const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(response => {
        return response.json()
    }).then (response => {
        console.log("website called function API.");
        count = response.count
        documet.getElemmentById("counter").innerText = count;

    }).catch(function(error){
        console.log(error);
    });
    return count;
}