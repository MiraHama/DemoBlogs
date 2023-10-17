import axios from "axios";
import { Dispatch } from "redux";
import { ActionTypes } from "./blogTypes";

const url = "https://localhost:5000/api/BlogPosts";

export interface PostBlogPost {
  id?: number;
  title: string;
  textBody: string;
  authorName: string;
  tags?: string[];
}

export const fetchBlogs = () => {
  return async (dispatch: Dispatch) => {
    try {
      dispatch({
        type: ActionTypes.fetchingBlogs,
      });
      const response = await axios.get(url);
      const blogs = response.data.data;
      dispatch({
        type: ActionTypes.fetchBlogs,
        payload: blogs,
      });
    } catch (error) {
      dispatch({
        type: ActionTypes.fetchBlogsError,
        payload: error,
      });
    }
  };
};

export const postBlogs = (blog: PostBlogPost) => {
  return async () => {
    const data = JSON.stringify(blog);
    try {
      const response = await axios.post(url, data, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      console.log(response.data);
    } catch (e) {
      console.log(e);
    }
  };
};
