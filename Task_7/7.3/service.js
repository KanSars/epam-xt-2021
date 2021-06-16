class Service {
  constructor() {
    this.repo = new Map();
  }

  getNewId() {
    let generateId = () => Math.ceil(Math.random() * (10000)).toString();
    let Id = generateId();

    while (this.repo.has(Id)) {
      Id = generateId();
    }

    return Id;
  }

  //принимает объект и позволяет добавить его в коллекцию
  add(user) {
    this.repo.set(this.getNewId(), user);
  }

  //принимает id и возвращает найденный объект или NULL если не найден
  getById(takenId) {
    if (this.repo.has(takenId)) {
      return this.repo.get(takenId);
    }
    return null;
  }

  //возвращает весь массив объектов
  getAll() {
    let arr = Array.from(this.repo.values());
    return arr;
  }

  //принимает id и возвращает удаленный объект
  deleteById(takenId) {
    this.tempPair = [];
    if (this.repo.has(takenId)) {
      this.tempPair = [takenId, this.repo.get(takenId)];
      this.repo.delete(takenId);
      return this.tempPair;
    }
    return false;
  }

  // принимает id первым параметром и объект-вторым. Обновляет поля объекта 
  // новыми значениями
  updateById(takenId, User4) {
    if (this.repo.has(takenId)) {
      for (let i in User4) {
        if (User4.hasOwnProperty(i)) {
          this.repo.get(takenId)[i] = User4[i];
        }
      }
    }
    return false;
  }

  // принимает id и заменяет старый объект - новым
  replaceById(takenId, User4) {
    if (this.repo.has(takenId)) {
      this.repo.set(takenId, User4);
    }
    return false;
  }

}