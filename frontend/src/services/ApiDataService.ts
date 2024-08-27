import axios from "axios";

class ApiDataService {
  async getAll() {
    return await axios.get("/");
  }
  async getById(studentId: any) {
    return axios.get("/" + studentId);
  }
  async create(data:any) {
    const response = await axios.post("/",data);

    return response.data;
  }
  async update(data:any) {
    const response = await axios.put("/",data);

    return response.data;
  }
  async delete(studentId: any) {
    const response = await axios.delete("/" + studentId);

    return response.data;
  }
}

export default new ApiDataService();
