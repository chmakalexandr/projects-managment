const rules = {
    employee: {
      static: ["project:list", "home-page:visit"],
      dynamic: {
        "project:list": ({userId, postOwnerId}) => {
          if (!userId || !postOwnerId) return false;
          return userId === postOwnerId;
        }
      }
    },
   resourcemanager: {
      static: [
        "users:list",
        "users:add",
        "project:create",
        "users:getSelf",
        "home-page:visit"        
      ],
      dynamic: {
        "project:edit": ({userId, postOwnerId}) => {
          if (!userId || !postOwnerId) return false;
          return userId === postOwnerId;
        },
        "project:list": ({userId, postOwnerId}) => {
            if (!userId || !postOwnerId) return false;
            return userId === postOwnerId;
         },
         "project:delete": ({userId, postOwnerId}) => {
            if (!userId || !postOwnerId) return false;
            return userId === postOwnerId;
         }
      }
    },
    Admin: {
      static: [
        "users:list",
        "users:create",
        "users:edit",
        "users:delete",
        "users:get",
        "users:getSelf",
        "home-page:visit",
      ]
    }
  };
  
  export default rules;