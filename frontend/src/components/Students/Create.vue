<template>
    <v-container>
      <v-card>
        <v-card-title>Criar Aluno</v-card-title>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-text-field v-model="student.name" label="Nome" :rules="[v => !!v || 'O nome é obrigatório']" required></v-text-field>
            <v-text-field v-model="student.email" label="E-mail" :rules="[v => !!v || 'O e-mail é obrigatório']" required></v-text-field>
            <v-text-field v-model="student.cpf" label="CPF" :rules="[v => !!v || 'O CPF é obrigatório']"></v-text-field>
            <v-text-field v-model="student.ra" label="Registro Acadêmico" :rules="[v => !!v || 'O Registro Acadêmico é obrigatório']"></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="submitCreate">Salvar</v-btn>
          <v-btn text @click="cancelCreate">Cancelar</v-btn>
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
          name: '',
          email: '',
          cpf: '',
          ra: '',
        },
        valid: false,
      };
    },
    methods: {
      async submitCreate() {
        if (this.$refs.form.validate()) {
          try {
            await ApiDataService.create(this.student);
            this.$router.push("/");
          } catch (error) {
            console.error('Erro ao salvar o aluno:', error);
          }
        }
      },
      cancelCreate() {
        this.$router.push("/");
      }
    }
  }
  </script>
  