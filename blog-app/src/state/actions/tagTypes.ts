import { Tag } from "../reducers/tagsReducer";

export interface FetchTagAction {
  type: ActionTypes.fetchTag;
  payload: Tag[];
}

export interface FetchingTagAction {
  type: ActionTypes.fetchingTag;
}

export interface FetchTagErrorAction {
  type: ActionTypes.fetchTagError;
  payload: any;
}

export enum ActionTypes {
  fetchTag,
  fetchingTag,
  fetchTagError,
}

export type Action = FetchTagAction | FetchingTagAction | FetchTagErrorAction;
