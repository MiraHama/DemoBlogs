import { Action, ActionTypes } from "../actions/authorTypes";
import { Blogpost } from "./blogsReducer";
import { Map, List } from "immutable";

export interface Author {
  id: number;
  name: string;
  posts: Blogpost[];
}
type InitialState = Map<string, any>;

const initialState: InitialState = Map({
  loading: false,
  authors: List<Author>(),
  error: null,
});

export const authorsReducer = (
  state: InitialState = initialState,
  action: Action
) => {
  switch (action.type) {
    case ActionTypes.fetchingAuthors:
      return state.set("loading", true);
    case ActionTypes.fetchAuthors:
      return state.merge({
        authors: List(action.payload),
        error: null,
        loading: false,
      });
    case ActionTypes.fetchAuthorsError:
      return state.merge({
        error: action.payload,
        loading: false,
      });
    default:
      return state;
  }
};
