import { Action, ActionTypes } from "../actions/blogTypes";
import { Map, List } from "immutable";

export interface Blogpost {
  id?: number;
  title: string;
  textBody: string;
  authorName: string;
  tags?: BlogTag[];
}

interface BlogTag {
  id: number;
  name: string;
}

type InitialState = Map<string, any>;

const initialState: InitialState = Map({
  loading: false,
  blogposts: List<Blogpost>(),
  error: null,
});

export const blogReducer = (state = initialState, action: Action) => {
  switch (action.type) {
    case ActionTypes.fetchingBlogs:
      return state.set("loading", true);
    case ActionTypes.fetchBlogs:
      return state.merge({
        blogposts: List(action.payload),
        error: null,
        loading: false,
      });
    case ActionTypes.fetchBlogsError:
      return state.merge({
        error: action.payload,
        loading: false,
      });
    default:
      return state;
  }
};
