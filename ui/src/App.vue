<template>
    <div class="main">
    <div class="form">
      <v-sheet width="450" class="mx-auto" color="e2e2e2">
    <v-form fast-fail @submit.prevent="postComment">
      <v-text-field
        v-model="newComment.author"
        label="Author"
        :rules="['Required']"
        hide-details="auto"
        ></v-text-field>

      <v-textarea label="Comment" v-model="newComment.text" maxlength="30" :rules="['Required']"></v-textarea>

      <v-btn type="submit" block class="mt-2" @submit="postComment">Post Comment</v-btn>
    </v-form>
  </v-sheet>
  </div>

    <div class="comSection">
      <h2>Comments</h2>
    <div v-for="comment in comments" :key="comment.id" class="comments" align="center">
      <v-card width="800" variant="tonal" class="vcard" align="center">
      <template v-slot:title>
        {{ comment.author }}
      </template>

      <template v-slot:subtitle>
        {{ parseDate(comment.date) }}
      </template>

      <template v-slot:text>
        {{ comment.text }}
      </template>
    </v-card>
    </div>
    </div>

  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      comments: [], // Array to store comments
      newComment: {
        author: "",
        text: "",
      },
    };
  },
  mounted() {
    this.fetchComments();
  },
  methods: {
    parseDate(date) {
    return new Date(Date.parse(date)).toLocaleString()
    },

    fetchComments() {
      axios.get('http://localhost:5094/api/comments').then((response) => {
        console.log(response.data);
          this.comments = response.data;
        })
        .catch((error) => {
          console.error("Error fetching comments: " + error);
        });
    },
    postComment() {
      // Send a POST request to your API to add a new comment
      axios.post('http://localhost:5094/api/comments', this.newComment)
        .then(() => {
          this.fetchComments(); // Refresh the comments list after posting
          this.newComment.author = "";
          this.newComment.text = "";
        })
        .catch((error) => {
          console.error("Error posting comment: " + error);
        });
    },
  },
};
</script>

<style>
* {
    margin: 0;
    padding: 0;

}

.comments {
    padding: 15px;
    margin-top: 15px;
}

.main {
  background-color: #d4d4d4;
}

.comSection {
  padding-top: 50px;
}

.form {
  padding-top: 50px;
}
</style>