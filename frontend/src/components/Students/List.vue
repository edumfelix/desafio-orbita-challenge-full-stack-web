<template>
  <v-container fluid>
    <v-card>
      <v-toolbar color="surface-light" extended light>

        <v-toolbar-title>Consulta de Alunos</v-toolbar-title>

        <v-card-text>
          <v-text-field append-inner-icon="mdi-magnify" density="compact" label="Search"
            variant="underlined" hide-details single-line></v-text-field>
        </v-card-text>

        <v-spacer></v-spacer>

        <template v-slot:extension>
          <v-fab class="ms-4" color="default" icon="mdi-plus" location="bottom left" size="40" absolute offset
            @click="createStudent()"></v-fab>
        </template>
      </v-toolbar>

      <v-data-table :headers="headers" :items="students" disable-pagination>
        <template v-slot:item.actions="{ item }">
          <v-icon class="me-2" size="small" @click="editStudent(item)">
            mdi-pencil
          </v-icon>
          <v-icon size="small" @click="openDeleteDialog(item)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>

    </v-card>

    <v-dialog v-model="confirmDeleteDialog" max-width="500">
      <v-card>
        <v-card-title class="text-h5">Confirmar Exclusão</v-card-title>
        <v-card-text>
          Tem certeza de que deseja excluir este aluno?
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" text @click="confirmDelete">Confirmar</v-btn>
          <v-btn color="secondary" text @click="confirmDeleteDialog = false">Cancelar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>

</template>

<script>

import ApiDataService from '@/services/ApiDataService';

export default {
  name: "list",
  data() {
    return {
      students: [],
      title: "",
      headers: [
        { title: 'Id', align: 'start', sortable: false, key: 'id' },
        { title: 'Nome', key: 'name', align: 'end' },
        { title: 'E-mail', key: 'email', align: 'end' },
        { title: 'CPF', key: 'cpf', align: 'end' },
        { title: 'Registro Acadêmico', key: 'ra', align: 'end' },
        { title: 'Ações', key: 'actions', align: 'end' },
      ],
      confirmDeleteDialog: false,
      studentToDelete: null,
    };
  },
  methods: {
    retrieveStudents() {
      ApiDataService.getAll()
        .then((response) => {
          this.students = response.data.map(this.getDisplayStudent);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveStudents();
    },

    createStudent() {
      this.$router.push({ path: '/StudentsCreate' });
    },

    editStudent(student) {
      this.$router.push({ path: '/StudentsEdit',  query: { id: student.id } });
    },

    getDisplayStudent(student) {
      return {
        id: student.id,
        name: student.name,
        email: student.email,
        cpf: student.cpf,
        ra: student.ra,
      };
    },
    openDeleteDialog(student) {
      this.studentToDelete = student;
      this.confirmDeleteDialog = true;
    },

    confirmDelete() {
      ApiDataService.delete(this.studentToDelete.id)
        .then(() => {
          this.refreshList();
          this.confirmDeleteDialog = false; // Fecha o diálogo após deletar
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.retrieveStudents();
  },
};

</script>
