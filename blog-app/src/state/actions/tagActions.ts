import axios from "axios";
import { Dispatch } from "redux";
import { ActionTypes } from "./tagTypes";

const url = "https://localhost:5000/api/Tags";

export const fetchTags = () => {
  return async (dispatch: Dispatch) => {
    try {
      dispatch({
        type: ActionTypes.fetchingTag,
      });
      const response = await axios.get(url);
      const blogTags = response.data.data;
      dispatch({
        type: ActionTypes.fetchTag,
        payload: blogTags,
      });
    } catch (error) {
      dispatch({
        type: ActionTypes.fetchTagError,
        payload: error,
      });
    }
  };
};
