window.addEventLisstner('DOMContentLoaded', (event) => {
    getVisitCount();
})
const functionApiUrl = "https://saratgetresumecounter.azurewebsites.net/api/GetResumeCounter?code=7atAhfbdefBUk6luvf9MZdCQoJ72vcvKJWAQiy9uotK6AzFuOYH0tA%3D%3D"
const functionApi = "http://localhost:7071/api/GetResumeCounter";

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
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