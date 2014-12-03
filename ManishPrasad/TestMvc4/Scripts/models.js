(function() {
    "use strict";

    var User = function(id, name, age, status) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.status = status;
    }

    var FreeUser = function(id, name, age, status) {
        User.call(this, id, name, age, status);
    }

    FreeUser.prototype = Object.create(User.prototype);
    FreeUser.prototype.constructor = FreeUser;

    var Post = function(user, content, time, comments) {
        this.user = user;
        this.content = content;
        this.time = time;
        this.comments = comments;
    }
    
    window.Models = {
        User: User,
        Post: Post
    }; 
})();
