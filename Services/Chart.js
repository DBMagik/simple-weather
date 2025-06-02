// Chart.js functions for weather forecast charts

window.createTemperatureChart = (labels, dayTemps, maxTemps, minTemps) => {
    const ctx = document.getElementById('temperatureChart');
    if (!ctx) return;

    // Destroy existing chart if it exists
    if (window.temperatureChartInstance) {
        window.temperatureChartInstance.destroy();
    }

    window.temperatureChartInstance = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Day Temperature',
                    data: dayTemps,
                    borderColor: 'rgb(255, 99, 132)',
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    tension: 0.4,
                    fill: false
                },
                {
                    label: 'Max Temperature',
                    data: maxTemps,
                    borderColor: 'rgb(255, 159, 64)',
                    backgroundColor: 'rgba(255, 159, 64, 0.2)',
                    tension: 0.4,
                    fill: false
                },
                {
                    label: 'Min Temperature',
                    data: minTemps,
                    borderColor: 'rgb(54, 162, 235)',
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    tension: 0.4,
                    fill: false
                }
            ]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: false,
                    title: {
                        display: true,
                        text: 'Temperature (°F)'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                }
            },
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                }
            }
        }
    });
};

window.createHumidityChart = (labels, humidity) => {
    const ctx = document.getElementById('humidityChart');
    if (!ctx) return;

    if (window.humidityChartInstance) {
        window.humidityChartInstance.destroy();
    }

    window.humidityChartInstance = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Humidity (%)',
                data: humidity,
                backgroundColor: 'rgba(75, 192, 192, 0.6)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    max: 100,
                    title: {
                        display: true,
                        text: 'Humidity (%)'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                }
            }
        }
    });
};

window.createUvChart = (labels, uvIndex) => {
    const ctx = document.getElementById('uvChart');
    if (!ctx) return;

    if (window.uvChartInstance) {
        window.uvChartInstance.destroy();
    }

    window.uvChartInstance = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'UV Index',
                data: uvIndex,
                borderColor: 'rgb(255, 206, 86)',
                backgroundColor: 'rgba(255, 206, 86, 0.2)',
                tension: 0.4,
                fill: true
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'UV Index'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                }
            }
        }
    });
};

window.createWindChart = (labels, windSpeed) => {
    const ctx = document.getElementById('windChart');
    if (!ctx) return;

    if (window.windChartInstance) {
        window.windChartInstance.destroy();
    }

    window.windChartInstance = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Wind Speed (mph)',
                data: windSpeed,
                backgroundColor: 'rgba(153, 102, 255, 0.6)',
                borderColor: 'rgba(153, 102, 255, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Wind Speed (mph)'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                }
            }
        }
    });
};