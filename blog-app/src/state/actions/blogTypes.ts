import { Blogpost } from "../reducers/blogsReducer";

export interface FetchBlogsAction {
  type: ActionTypes.fetchBlogs;
  payload: Blogpost[];
}

export interface PostBlogsAction {
  type: ActionTypes.postBlogs;
  payload: Blogpost[];
}

export interface FetchingBlogsAction {
  type: ActionTypes.fetchingBlogs;
}

export interface FetchBlogsErrorAction {
  type: ActionTypes.fetchBlogsError;
  payload: any;
}

export enum ActionTypes {
  fetchBlogs,
  postBlogs,
  fetchingBlogs,
  fetchBlogsError,
}

export type Action =
  | FetchBlogsAction
  | PostBlogsAction
  | FetchingBlogsAction
  | FetchBlogsErrorAction;
