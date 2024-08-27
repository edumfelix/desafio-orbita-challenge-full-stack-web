<template>
    <v-container>
      <v-card>
        <v-card-title>Editar Aluno</v-card-title>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-text-field v-model="student.name" label="Nome" :rules="[v => !!v || 'O nome é obrigatório']" required></v-text-field>
            <v-text-field v-model="student.email" label="E-mail" :rules="[v => !!v || 'O e-mail é obrigatório']" required></v-text-field>
            <v-text-field v-model="student.cpf" label="CPF" readonly></v-text-field>
            <v-text-field v-model="student.ra" label="Registro Acadêmico" readonly></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="submitEdit">Salvar</v-btn>
          <v-btn text @click="cancelEdit">Cancelar</v-btn>
        </v-card-actions>
      </v-card>
    </v-container>
  </template>
  
  <script>
  import ApiDataService from '@/services/ApiDataService';
  
  export default {
    name: "StudentsDetails",
    data() {
      return {
        student: {
          id: '',
          name: '',
          email: '',
          cpf: '',
          ra: '',
        },
        valid: false,
      };
    },
    methods: {
      async fetchStudent() {
        try {
          const id = this.$route.query['id'];
          
          if (id) {
            const response = await ApiDataService.getById(id);
            this.student = response.data;
          } else {
            console.error('Id do aluno não está disponível.');
          }
        } catch (error) {
          console.error('Erro ao carregar os dados do aluno:', error);
        }
      },
      async submitEdit() {
        if (this.$refs.form.validate()) {
          try {
            await ApiDataService.update(this.student);
            this.$router.push("/");
          } catch (error) {
            console.error('Erro ao editar o aluno:', error);
          }
        }
      },
      cancelEdit() {
        this.$router.push("/");
      }
    },
    mounted() {
      this.fetchStudent();
    }
  }
  </script>
  