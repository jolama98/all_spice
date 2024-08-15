export class Recipe {
  constructor(data){
this.id = data.id || data._id
this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creator = data.creator
  }
}


