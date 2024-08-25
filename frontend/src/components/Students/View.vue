<template>

  <v-card title="Consulta de Alunos" flat>
    <template v-slot:text>
      <v-text-field v-model="search" label="Search" prepend-inner-icon="mdi-magnify" variant="outlined" hide-details
        single-line></v-text-field>
    </template>

    <v-data-table-server v-model:items-per-page="itemsPerPage" :headers="headers" :items="serverItems"
      :items-length="totalItems" :loading="loading" :search="search" item-value="name" @update:options="loadItems">
      <template v-slot:item.actions="{ item }">
      <v-icon
        class="me-2"
        size="small"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        size="small"
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    </v-data-table-server>
  </v-card>
</template>

<script>
import axios from 'axios';

const API = {
  async fetch({ page, itemsPerPage, sortBy }) {
    try {
      let url = `https://localhost:7198/api/v1/Student?page=${page}&itemsPerPage=${itemsPerPage}`;

      if (sortBy.length) {
        const sortKey = sortBy[0].key;
        const sortOrder = sortBy[0].order;
        url += `&sortBy=${sortKey}&sortOrder=${sortOrder}`;
      }

      const response = await axios.get(url);

      if (Array.isArray(response.data)) {
        return {
          items: response.data,
          total: 0
        };
      } else {
        console.error('Dados da API no formato inesperado:', response.data);
        return { items: [], total: 0 };
      }
    } catch (error) {
      console.error('Erro ao buscar dados:', error);
      return { items: [], total: 0 };
    }
  },
};

export default {
  data: () => ({
    dialog: false,
    dialogDelete: false,
    itemsPerPage: 10,
    search: '',
    headers: [
      { title: 'Id', align: 'start', sortable: false, key: 'id' },
      { title: 'Nome', key: 'name', align: 'end' },
      { title: 'E-mail', key: 'email', align: 'end' },
      { title: 'CPF', key: 'cpf', align: 'end' },
      { title: 'Registro Acadêmico', key: 'ra', align: 'end' },
      { title: 'Ações', key: 'actions', align: 'end' },
    ],
    search: '',
    serverItems: [],
    loading: true,
    totalItems: 0,
  }),
  computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      //this.initialize()
    },

  methods: {
    async loadItems({ page, itemsPerPage, sortBy }) {
      this.loading = true;
      try {
        const { items, total } = await API.fetch({ page, itemsPerPage, sortBy });
        this.serverItems = items;
        this.totalItems = total;
      } catch (error) {
        console.error('Erro ao carregar itens:', error);
        this.serverItems = [];
        this.totalItems = 0;
      } finally {
        this.loading = false;
      }
    },
  },
  editItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },
      deleteItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.desserts[this.editedIndex], this.editedItem)
        } else {
          this.desserts.push(this.editedItem)
        }
        this.close()
      },
}
</script>
