import axios from "axios";
import { Dispatch } from "redux";
import { ActionTypes } from "./authorTypes";

const url = "https://localhost:5000/api/Authors";

export const fetchAuthors = () => {
  return async (dispatch: Dispatch) => {
    try {
      dispatch({
        type: ActionTypes.fetchingAuthors,
      });
      const response = await axios.get(url);
      const authors = response.data.data;
      dispatch({
        type: ActionTypes.fetchAuthors,
        payload: authors,
      });
    } catch (error) {
      dispatch({
        type: ActionTypes.fetchAuthorsError,
        payload: error,
      });
    }
  };
};
