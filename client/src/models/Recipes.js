export class Recipe {
  constructor(data) {
    this.id = data.id || data._id
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creator = data.creator
  }
  get recipeBackgroundImage() {
    return `url(${this.img})`
  }
}




// const object = {
//   "id": 1,
//   "createdAt": "2024-08-14T21:32:43",
//   "updatedAt": "2024-08-14T21:32:43",
//   "title": "Big Jerms' famous Shakshuka",
//   "instructions": "Take your tomatoes and cook them, then add the eggs. Boom, Shakshuka.",
//   "img": "https://images.unsplash.com/photo-1614570218825-c2a3be79b0fd?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8c2hha3NodWthfGVufDB8fDB8fHww",
//   "category": "breakfast",
//   "creatorId": "6691cd264de80d398f94368a",
//   "creator": {
//     "id": "6691cd264de80d398f94368a",
//     "name": "bartdude19@dude.com",
//     "picture": "https://s.gravatar.com/avatar/7712820af5b5656a3dde11d4c5d5f5a5?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fba.png"
//   }
// }
