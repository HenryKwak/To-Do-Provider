new Vue({
    el: '#app',
    data: {
        newTask: '',
        tasks: [],
        searchQuery: '',
        selectedProvider: 'Database',
        debounceTimeout: null
    },
    created() {
        this.fetchTasks();
    },
    methods: {
        fetchTasks() {
            axios.get(`/api/todo/GetList?providerType=${this.selectedProvider}`)
                .then(response => {
                    this.tasks = response.data;
                })
                .catch(error => {
                    console.error("There was an error fetching the tasks!", error);
                });
        },
        addTask() {
            if (this.newTask.trim() !== '') {
                axios.post(`/api/todo/AddTask?providerType=${this.selectedProvider}`, { task: this.newTask, isCompleted: false })
                    .then(response => {
                        this.tasks.push(response.data);
                        this.newTask = '';
                    })
                    .catch(error => {
                        console.error("There was an error adding the task!", error);
                    });
            }
        },
        editTask(index) {
            const updatedTask = prompt('Edit task:', this.tasks[index].task);
            if (updatedTask !== null) {
                const task = this.tasks[index];
                axios.put(`/api/todo/EditTask?providerType=${this.selectedProvider}&id=${task.id}`, { ...task, task: updatedTask })
                    .then(() => {
                        this.$set(this.tasks, index, { ...task, task: updatedTask });
                    })
                    .catch(error => {
                        console.error("There was an error updating the task!", error);
                    });
            }
        },
        deleteTask(index) {
            const task = this.tasks[index];
            axios.delete(`/api/todo/DeleteTask?providerType=${this.selectedProvider}&id=${task.id}`)
                .then(() => {
                    this.tasks.splice(index, 1);
                })
                .catch(error => {
                    console.error("There was an error deleting the task!", error);
                });
        },
        searchTasks() {
            clearTimeout(this.debounceTimeout);
            this.debounceTimeout = setTimeout(() => {
                axios.get(`/api/todo/SearchTasks?providerType=${this.selectedProvider}&query=${this.searchQuery}`)
                    .then(response => {
                        this.tasks = response.data;
                    })
                    .catch(error => {
                        console.error("There was an error searching the tasks!", error);
                    });
            }, 300);
        }
    },
});